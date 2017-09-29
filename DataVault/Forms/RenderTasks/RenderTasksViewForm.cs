using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Forms;
using DataVault.DataModels;
using DataVault.Forms.Users;

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
            db.RenderTasks.Load();
            ReloadData();
        }

        private void ReloadData()
        {
            // filter data
            /*var filterName = UserFiltersForm.TaskName;
            var filterMail = UserFiltersForm.FilterEmail;
            var filterBalanceFrom = UserFiltersForm.TaskPriceFrom;
            var filterBalanceTo = UserFiltersForm.TaskPriceTo;

            var usersList = db.Users.Local.Where(u =>
            {
                if (filterName != "" && !u.Name.ToLower().StartsWith(filterName))
                    return false;
                if (filterMail != "" && !u.Email.ToLower().StartsWith(filterMail))
                    return false;
                if (filterBalanceFrom > -1 && u.Balance < filterBalanceFrom)
                    return false;
                if (filterBalanceTo > -1 && u.Balance > filterBalanceTo)
                    return false;

                return true;
            }).ToList();*/
            var tasksList = db.RenderTasks.Local.ToList();

            // show status
            var itemsCount = tasksList.Count;
            var pageSize = GetPageSize(itemsCount);
            pageCount = (int) Math.Ceiling((double) itemsCount / pageSize);

            FormatStatusLabel(pageSize, itemsCount);

            // sort data
            /*IEnumerable<User> users = new List<User>();
            switch (dataGrid.SortColumnIndex)
            {
                case 0:
                    users = usersList.OrderBy(u => u.Id);
                    break;
                case 1:
                    users = usersList.OrderBy(u => u.Name);
                    break;
                case 2:
                    users = usersList.OrderBy(u => u.Email);
                    break;
                case 3:
                    users = usersList.OrderBy(u => u.Balance);
                    break;
            }*/
            IEnumerable<RenderTask> tasks = tasksList.OrderBy(t => t.Id);

            if (dataGrid.BackSort)
                tasks = tasks.Reverse();

            // set pagination
            tasks = tasks.Skip(pageSize * pageIndex).Take(pageSize);

            // set buttons states
            dataGrid.DataSource = tasks.ToList();

            foreach (var i in new [] {6,7,8})
            {
                dataGrid.Columns[i].Visible = false;

            }

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
            var ff = new UserFiltersForm();
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
            if (new AddEditUserForm().ShowDialog() == DialogResult.OK)
            {
                db.Users.Load();
                ReloadData();
            }
        }

        private void EditTask()
        {
            var id = (int) dataGrid.SelectedRows[0].Cells[0].Value;
            var user = db.Users.Find(id);
            if (new AddEditUserForm(user).ShowDialog() == DialogResult.OK)
            {
                db.Users.Load();
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
            if (e.RowIndex<0) // header cell
                return;

            EditTask();
        }
        
        private void ReloadTasks()
        {
            pageIndex = 0;
            dataGrid.SortColumnIndex = 0;
            dataGrid.BackSort = false;
            ReloadData();
        }
        
        private void RemoveTask()
        {
            var id = (int) dataGrid.SelectedRows[0].Cells[0].Value;
            db.Users.Remove(db.Users.Find(id));

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                var username = (string) dataGrid.SelectedRows[0].Cells[1].Value;
                MessageBox.Show(this,
                    $"Невозможно удалить пользователя {username}: в базе имеются связанные с ним задачи.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.Dispose();
                db = new RenderFarm();
                return;
            }

            db.Users.Load();
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
    }
}