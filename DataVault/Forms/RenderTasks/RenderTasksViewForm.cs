using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using DataVault.DataModels;
using DataVault.Forms.Users;
using ff = DataVault.Forms.RenderTasks.RenderTaskFilterForm;

namespace DataVault.Forms.RenderTasks
{
    public partial class RenderTasksViewForm : Form
    {
        private RenderFarm db = new RenderFarm();
        private int pageCount;
        private int pageIndex;

        public RenderTasksViewForm()
        {
            InitializeComponent();

            controlBar.FilterButtonClick += (s, e) => FilterTasks();
            controlBar.AddButtonClick += (s, e) => AddTask();
            controlBar.EditButtonClick += (s, e) => EditTask();
            controlBar.RemoveButtonClick += (s, e) => RemoveTask();
            controlBar.ReloadButtonClick += (s, e) => ReloadTasks();

            controlBar.PaginationButtonClick += (s, e) => PaginatePage(e.IsNextPage);
            controlBar.PaginationSizeChanged += (s, e) => PaginationSizeChanged();
        }

        private void UserViewForm_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            // filter data
            var tasksList = db.RenderTasks.ToList().Where(t =>
            {
                if (ff.TaskName != "" && !t.Name.ToLower().StartsWith(ff.TaskName))
                    return false;

                if (ff.TaskProjectEnabled && t.Project.Id != ff.TaskProject.Id)
                    return false;
                if (ff.TaskSoftwareEnabled && t.Software.Id != ff.TaskSoftware.Id)
                    return false;

                if (ff.TaskStartFromEnabled && t.StartTime < ff.TaskStartFrom)
                    return false;
                if (ff.TaskStartToEnabled && t.StartTime > ff.TaskStartTo)
                    return false;

                if (ff.TaskPriceFrom != -1m && t.Price < ff.TaskPriceFrom)
                    return false;
                if (ff.TaskPriceTo != -1m && t.Price > ff.TaskPriceTo)
                    return false;

                if (ff.TaskTimeFrom != -1m && t.RenderTime < ff.TaskTimeFrom)
                    return false;
                if (ff.TaskTimeTo != -1m && t.RenderTime > ff.TaskTimeTo)
                    return false;

                return true;
            }).ToList();

            // show status
            var itemsCount = tasksList.Count;
            var pageSize = GetPageSize(itemsCount);
            pageCount = (int) Math.Ceiling((double) itemsCount / pageSize);

            FormatStatusLabel(pageSize, itemsCount);

            // sort data
            var actions = new List<Func<RenderTask, object>>
            {
                t => t.Id,
                t => t.Name,
                t => t.Price,
                t => t.StartTime,
                t => t.RenderTime,
                t => t.Project.Name,
                t => t.Software.FullName,
                t => t.Description
            };
            IEnumerable<RenderTask> tasks = tasksList.OrderBy(actions[dataGrid.SortColumnIndex]);

            if (dataGrid.BackSort)
                tasks = tasks.Reverse();

            // set pagination and map columns
            var data = tasks.Skip(pageSize * pageIndex).Take(pageSize).Select(t => new
            {
                Id = t.Id,
                Name = t.Name,
                Price = t.Price,
                StartTime = t.StartTime,
                RenderTime = t.RenderTime,
                Project = t.Project.Name,
                Software = t.Software.FullName,
                Description = t.Description
            });

            // set buttons states
            dataGrid.DataSource = data.ToList();

            controlBar.NextPageButtonEnabled = pageIndex < pageCount - 1;
            controlBar.PrevPageButtonEnabled = pageIndex > 0;
            controlBar.EditButtonEnabled = controlBar.RemoveButtonEnabled = dataGrid.SelectedRows.Count == 1;
        }

        private void FormatStatusLabel(int pageSize, int itemsCount)
        {
            if (itemsCount == 0)
            {
                controlBar.StatusText = "Нет записей";
                return;
            }

            var firstItemIndex = pageSize * pageIndex + 1;
            var lastItemIndex = Math.Min(pageSize * (pageIndex + 1), itemsCount);
            controlBar.StatusText =
                $"Страница {pageIndex + 1} из {pageCount} [{firstItemIndex} - {lastItemIndex} из {itemsCount}]";
        }

        private int GetPageSize(int itemsCount)
        {
            return controlBar.PaginationSize > 0
                ? controlBar.PaginationSize
                : itemsCount;
        }

        private void FilterTasks()
        {
            var ff = new ff();
            var result = ff.ShowDialog(this);
            if (result != DialogResult.Cancel)
            {
                pageIndex = 0;
                ReloadData();
            }
        }

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReloadData();
        }

        private void AddTask()
        {
            if (new AddEditRenderTaskForm().ShowDialog() == DialogResult.OK)
            {
                ReloadData();
            }
        }

        private void EditTask()
        {
            var id = (int) dataGrid.SelectedRows[0].Cells[0].Value;
            var task = db.RenderTasks.ToList().Find(t => t.Id == id);
            if (new AddEditRenderTaskForm(task).ShowDialog() == DialogResult.OK)
            {
                db.RenderTasks.Load();
                ReloadData();
            }
        }

        private void dataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGrid.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

            dataGrid.Columns[dataGrid.SortColumnIndex].HeaderCell.SortGlyphDirection =
                dataGrid.BackSort ? SortOrder.Descending : SortOrder.Ascending;
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            controlBar.EditButtonEnabled = controlBar.RemoveButtonEnabled = dataGrid.SelectedRows.Count == 1;
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) // header cell
                return;

            EditTask();
        }

        private void ReloadTasks()
        {
            pageIndex = 0;
            dataGrid.SortColumnIndex = 0;
            dataGrid.BackSort = false;

            db.RenderTasks.Load();
            ReloadData();
        }

        private void RemoveTask()
        {
            var id = (int) dataGrid.SelectedRows[0].Cells[0].Value;
            db.RenderTasks.Remove(db.RenderTasks.Find(id));

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                var name = (string) dataGrid.SelectedRows[0].Cells[1].Value;
                MessageBox.Show(this,
                    $"Невозможно удалить задачу {name}: в базе имеются связанные с ней данные", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.Dispose();
                db = new RenderFarm();
                return;
            }

            db.RenderTasks.Load();
            ReloadData();
        }


        private void PaginatePage(bool isNextPage)
        {
            if (isNextPage)
                pageIndex++;
            else
                pageIndex--;

            ReloadData();
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveTask();
        }

        private void PaginationSizeChanged()
        {
            pageIndex = 0;
            ReloadData();
        }
        
        private void RenderTasksViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }
    }
}