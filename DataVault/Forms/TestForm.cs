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
    public partial class TestForm : Form
    {
        private DataView dv;

        private int pageIndex;
        public int PageIndex
        {
            get => pageIndex;
            set
            {
                pageIndex = value;

                btnNext.Enabled = pageIndex != PageCount - 1;
                btnPrev.Enabled = pageIndex != 0;
                
                int skip = PageIndex * pageSize;
                dv = new DataView(db.DataTable(dbRenderTasks.Skip(skip).Take(pageSize).ToString()));

                advancedDataGridView1.ClearFilter();
                advancedDataGridView1.ClearSort();
                advancedDataGridView1.DataSource = dv;
            }
        }

        private int pageSize = 25;
        private int PageCount => (int)Math.Ceiling((double)dbRenderTasks.Count() / pageSize);

        readonly RenderFarm db = new RenderFarm();
        private readonly IOrderedQueryable<RenderTask> dbRenderTasks;

        public TestForm()
        {
            InitializeComponent();

            dbRenderTasks = db.RenderTasks.OrderBy(i => i.Id);

            var sqlQuery = dbRenderTasks.Take(pageSize).ToString();
            dv = new DataView(db.DataTable(sqlQuery));

            advancedDataGridView1.DataSource = dv;
            cbPageSize.SelectedIndex = 1;
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            dv.RowFilter = advancedDataGridView1.FilterString;
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            dv.Sort = advancedDataGridView1.SortString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageIndex--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PageIndex++;
        }

        private void cbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = cbPageSize.SelectedIndex == cbPageSize.Items.Count - 1
                ? Int32.MaxValue
                : int.Parse((string) cbPageSize.SelectedItem);
            PageIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var dataSource = advancedDataGridView1.DataSource;
        }
    }
}
