using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataVault.DataModels;

namespace DataVault.Forms
{
    public partial class UserViewForm : Form
    {
        readonly RenderFarm db = new RenderFarm();
        private IEnumerable<User> users;

        public UserViewForm()
        {
            InitializeComponent();
        }

        private void UserViewForm_Load(object sender, EventArgs e)
        {
            db.Users.Load();
            users = db.Users.Local.OrderBy(u => u.Id).ToList();
            dataGrid.DataSource = users;

            dataGrid.Columns[0].ReadOnly = true;
            dataGrid.Columns[4].Visible = false;
        }

        private void FilterSortGridView()
        {
            var filterName = UserFiltersForm.FilterName;
            var filterMail = UserFiltersForm.FilterEmail;
            var filterBalanceFrom = UserFiltersForm.FilterBalanceFrom;
            var filterBalanceTo = UserFiltersForm.FilterBalanceTo;

            users = users.Where(u =>
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
            });

            switch (lastColumnIndex)
            {
                case 0:
                    users = users.OrderBy(u => u.Id);
                    break;
                case 1:
                    users = users.OrderBy(u => u.Name);
                    break;
                case 2:
                    users = users.OrderBy(u => u.Email);
                    break;
                case 3:
                    users = users.OrderBy(u => u.Balance);
                    break;
            }

            if (desc)
            {
                users = users.Reverse();
            }

            dataGrid.DataSource = users.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ff = new UserFiltersForm();
            var result = ff.ShowDialog(this);
            if (result != DialogResult.Cancel)
            {
                FilterSortGridView();
            }
        }

        private int lastColumnIndex;
        private bool desc;

        private void dataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnIndex = e.ColumnIndex;
            if (columnIndex == lastColumnIndex)
                desc = !desc;
            else desc = false;

            lastColumnIndex = columnIndex;
            FilterSortGridView();
        }
    }
}