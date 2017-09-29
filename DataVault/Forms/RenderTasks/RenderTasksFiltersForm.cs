using System;
using System.Data.Entity;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DataVault.DataModels;

namespace DataVault.Forms.RenderTasks
{
    public partial class RenderTaskFilterForm : Form
    {
        public static string TaskName { get; private set; } = "";

        public static decimal TaskPriceFrom { get; private set; } = -1m;
        public static decimal TaskPriceTo { get; private set; } = -1m;

        public static decimal TaskTimeFrom { get; private set; } = -1m;
        public static decimal TaskTimeTo { get; private set; } = -1m;

        public static DateTime TaskStartFrom{ get; private set; } = DateTime.Now;
        public static DateTime TaskStartTo { get; private set; } = DateTime.Now;

        public static bool TaskStartFromEnabled { get; private set; }
        public static bool TaskStartToEnabled { get; private set; }
        
        public static bool TaskProjectEnabled { get; private set; }
        public static bool TaskSoftwareEnabled { get; private set; }
        
        public static Project TaskProject { get; private set; }
        public static Software TaskSoftware { get; private set; }

        private RenderFarm db = new RenderFarm();
        
        public RenderTaskFilterForm()
        {
            InitializeComponent();
            InitCombobexes();
            FillFilters();
        }

        private void FillFilters()
        {
            name.Text = TaskName;
            project.SelectedItem = TaskProject;
            software.SelectedItem = TaskSoftware;

            if (TaskPriceFrom > -1m)
                priceFrom.Text = TaskPriceFrom.ToString();

            if (TaskPriceTo > -1m)
                priceTo.Text = TaskPriceTo.ToString();

            if (TaskTimeFrom > -1m)
                renderTimeFrom.Text = TaskTimeFrom.ToString();

            if (TaskTimeTo > -1m)
                renderTimeTo.Text = TaskTimeTo.ToString();

            startDateFrom.Checked = TaskStartFromEnabled;
            startDateTo.Checked = TaskStartToEnabled;
            startDateFrom.Value = TaskStartFrom;
            startDateTo.Value = TaskStartTo;
        }

        private void InitCombobexes()
        {
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
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var pFrom = priceFrom.Text != ""
                ? Decimal.Parse(priceFrom.Text, NumberStyles.Any)
                : -1m;

            var pTo = priceTo.Text != ""
                ? Decimal.Parse(priceTo.Text, NumberStyles.Any)
                : -1m;

            if (pFrom > 0 && pTo >0 && pFrom > pTo)
            {
                var buf = pFrom;
                pFrom = pTo;
                pTo = buf;
            }

            var dateFrom = startDateFrom.Value;
            var dateTo = startDateFrom.Value;

            if (dateFrom > dateTo)
            {
                var buf = dateFrom;
                dateFrom = dateTo;
                dateTo = buf;
            }
            

            if (sender.Equals(btnOk))
            {
                TaskName = name.Text.ToLower();
                TaskPriceFrom = pFrom;
                TaskPriceTo = pTo;
                TaskStartFrom = dateFrom;
                TaskStartTo = dateTo;
                TaskTimeFrom = renderTimeFrom.Text.Length >0 ? decimal.Parse(renderTimeFrom.Text) : -1m;
                TaskTimeTo = renderTimeTo.Text.Length > 0 ? decimal.Parse(renderTimeTo.Text) : -1m;
                TaskProject = (Project)project.SelectedItem;
                TaskSoftware = (Software) software.SelectedItem;

                TaskStartFromEnabled = startDateFrom.Checked;
                TaskStartToEnabled = startDateTo.Checked;

                TaskProjectEnabled = cbProjectEnabled.Checked;
                TaskSoftwareEnabled = cbSoftwareEnabled.Checked;
            }
            else if (sender.Equals(btnIgnore))
            {
                TaskName = "";
                TaskPriceFrom = TaskPriceTo = TaskTimeFrom = TaskTimeTo = -1m;
                TaskProjectEnabled = TaskSoftwareEnabled = TaskStartFromEnabled = TaskStartToEnabled = false;
            }
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