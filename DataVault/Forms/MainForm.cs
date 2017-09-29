using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataVault.DataModels;
using DataVault.Forms.RenderTasks;
using DataVault.Forms.Users;

namespace DataVault
{
    public partial class MainForm : Form
    {
        readonly Form[] forms = {
            new UserViewForm(),
            new RenderTasksViewForm()
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            forms[comboBox1.SelectedIndex].Show(this);
            this.Hide();

            var tableName = (string) comboBox1.SelectedItem;
            tableName = tableName.Replace(" ", "");
            //TableViewForm form = new TableViewForm(tableName,this);
            //form.Show(this);
            //this.Hide();
        }
    }
}
