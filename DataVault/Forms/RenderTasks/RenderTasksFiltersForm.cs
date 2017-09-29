using System;
using System.Data.Entity;
using System.Globalization;
using System.Windows.Forms;
using DataVault.DataModels;

namespace DataVault.Forms.RenderTasks
{
    public partial class RenderTaskFilterForm : Form
    {
        public static string TaskName { get; private set; } = "";
        public static decimal TaskPriceFrom { get; private set; } = -1m;
        public static decimal TaskPriceTo { get; private set; } = -1m;

        public static DateTime TaskRenderStartFrom{ get; private set; } = DateTime.Now;
        public static DateTime TaskRenderStartTo { get; private set; } = DateTime.Now;

        public static bool TaskStartFromEnabled { get; private set; }
        public static bool TaskStartToEnabled { get; private set; }
        
        public static bool TaskProjectEnabled { get; private set; }
        public static bool TaskSoftwareEnabled { get; private set; }

        private RenderFarm db = new RenderFarm();

        public RenderTaskFilterForm()
        {
            InitializeComponent();

            db.Projects.Load();
            db.Softwares.Load();

            project.DataSource = db.Projects.Local;
            project.ValueMember = "Id";
            project.DisplayMember = "Name";
            project.Enabled = cbProjectEnabled.Checked = TaskProjectEnabled;
            
            software.DataSource = db.Softwares.Local;
            software.ValueMember = "Id";
            software.DisplayMember = "FullName";
            software.Enabled = cbSoftwareEnabled.Checked = TaskSoftwareEnabled;

            name.Text = TaskName;
            
            if (TaskPriceFrom > -1m)
                priceFrom.Text = TaskPriceFrom.ToString();

            if (TaskPriceTo > -1m)
                priceTo.Text = TaskPriceTo.ToString();

            startDateFrom.Checked = TaskProjectEnabled;
            startDateTo.Checked = TaskSoftwareEnabled;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            var bFrom = priceFrom.Text != ""
                ? Decimal.Parse(priceFrom.Text, NumberStyles.Any)
                : -1m;

            var bTo = priceTo.Text != ""
                ? Decimal.Parse(priceTo.Text, NumberStyles.Any)
                : -1m;

            if (bFrom > 0 && bTo >0 && bFrom > bTo)
            
            {
                var buf = bFrom;
                bFrom = bTo;
                bTo = buf;
            }
            

            if (sender.Equals(btnOk))
            {
                TaskName = name.Text.ToLower();
                TaskPriceFrom = bFrom;
                TaskPriceTo = bTo;
            }
            else if (sender.Equals(btnIgnore))
            {
                TaskName = "";
                TaskPriceFrom = TaskPriceTo = -1m;
            }

            Close();
        }

        private void balanceFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            var text = ((TextBox) sender).Text;
            if (ch == '.' && text.IndexOf('.') > -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != '.' && ch!=8)
            {
                e.Handled = true;
            }
        }

        private void cbSoftwareEnabled_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox) sender;
            if (cb.Equals(cbProjectEnabled))
            {
                project.Enabled = cb.Checked;
            }
            else software.Enabled = cb.Checked;
        }
    }
}