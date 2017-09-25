using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataVault.DataModels;
using DataVault.Forms.Users;
using SortOrder = System.Windows.Forms.SortOrder;

namespace DataVault.Forms
{
    public partial class UserViewForm : Form
    {
        RenderFarm db = new RenderFarm();

        private int sortColumnIndex;
        private bool desc;
        private int pageIndex;
        private int pageCount;

        public UserViewForm()
        {
            InitializeComponent();
        }

        private void UserViewForm_Load(object sender, EventArgs e)
        {
            cbPagination.SelectedIndex = 1;
            db.Users.Load();
            ReloadData();
        }

        private void ReloadData()
        {
            // filter data
            var filterName = UserFiltersForm.FilterName;
            var filterMail = UserFiltersForm.FilterEmail;
            var filterBalanceFrom = UserFiltersForm.FilterBalanceFrom;
            var filterBalanceTo = UserFiltersForm.FilterBalanceTo;
            
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
            }).ToList();
            
            // show status
            var itemsCount = usersList.Count;
            var pageSize = GetPageSize(itemsCount);
            pageCount = (int)Math.Ceiling((double)itemsCount / pageSize);

            FormatStatusLabel(pageSize, itemsCount);

            // sort data
            IEnumerable<User> users = new List<User>();
            switch (sortColumnIndex)
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
            }

            if (desc)
            {
                users = users.Reverse();
            }

            // set pagination
            users = users.Skip(pageSize * pageIndex).Take(pageSize);

            // set buttons states
            dataGrid.DataSource = users.ToList();
            dataGrid.Columns[4].Visible = false;

            btnNext.Enabled = pageIndex < pageCount - 1;
            btnPrev.Enabled = pageIndex > 0;
            btnEdit.Enabled = btnRemove.Enabled = dataGrid.SelectedRows.Count == 1;
        }

        private void FormatStatusLabel(int pageSize, int itemsCount)
        {
            if (itemsCount == 0)
            {
                lbPage.Text = "Нет записей";
                return;
            }

            var firstItemIndex = pageSize * pageIndex + 1;
            var lastItemIndex = Math.Min(pageSize * (pageIndex+1), itemsCount);
            lbPage.Text = $"Страница {pageIndex + 1} из {pageCount} [{firstItemIndex} - {lastItemIndex} из {itemsCount}]";
        }

        private int GetPageSize(int itemsCount)
        {
            int pageSize;
            if (cbPagination.SelectedIndex != cbPagination.Items.Count - 1)
            {
                pageSize = int.Parse((string) cbPagination.SelectedItem);
            }
            else pageSize = itemsCount;
            return pageSize;
        }

        private void btnFilters_Click(object sender, EventArgs e)
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
            var columnIndex = e.ColumnIndex;
            if (columnIndex == sortColumnIndex)
                desc = !desc;
            else desc = false;

            dataGrid.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                desc ? SortOrder.Descending : SortOrder.Ascending;

            sortColumnIndex = columnIndex;
            ReloadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (new AddEditUserForm().ShowDialog() == DialogResult.OK)
            {
                db.Users.Load();
                ReloadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void EditUser()
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
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            dataGrid.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection =
                desc ? SortOrder.Descending : SortOrder.Ascending;
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dataGrid.SelectedRows.Count == 1;
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditUser();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            pageIndex = 0;
            sortColumnIndex = 0;
            desc = false;
            ReloadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveUser();
        }

        private void RemoveUser()
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnNext))
            {
                pageIndex++;
            }
            else
            {
                pageIndex--;
            }

            ReloadData();
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveUser();
        }

        private void cbPagination_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = 0;
            ReloadData();
        }
    }
}