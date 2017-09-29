using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using DataVault.DataModels;

namespace DataVault.Forms.RenderTasks
{
    public partial class AddEditRenderTaskForm : Form
    {
        private readonly Control[] fileds;
        private readonly RenderFarm db;
        private RenderTask task;

        public AddEditRenderTaskForm(RenderTask task = null)
        {
            InitializeComponent();
            this.task = task;

            db = new RenderFarm();

            db.Softwares.Load();
            db.Projects.Load();

            taskProject.DataSource = db.Projects.Local;
            taskProject.ValueMember = "Id";
            taskProject.DisplayMember = "Name";

            taskSoftware.DataSource = db.Softwares.Local;
            taskSoftware.ValueMember = "Id";
            taskSoftware.DisplayMember = "FullName";
            

            if (task != null)
            {
                taskName.Text = task.Name;
                taskPrice.Text = task.Price.ToString();
                taskRenderTime.Text = task.RenderTime.ToString();
                taskDesc.Text = task.Description ?? "";
                taskProject.SelectedItem = db.Projects.Local.First(p => p.Id==task.Id);
                taskSoftware.SelectedItem = db.Softwares.Local.First(s => s.Id == task.Software.Id);

                btnOk.Text = "Обновить";
                Text = "Редактирование задачи";
            }

            fileds = new Control[] {taskName, taskPrice, taskRenderTime,taskProject,taskSoftware };

            foreach (var control in fileds)
            {
                errorProvider.SetIconPadding(control, 5);
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void fields_Validating(object sender, CancelEventArgs e)
        {
            if (sender.Equals(taskName))
            {
                if (taskName.Text.Length < 1 || taskName.Text.Length > 200)
                    errorProvider.SetError(taskName, "Имя задачи должно содержать от 1 до 200 символов");
                else errorProvider.SetError(taskName, "");
            }
            else if (sender.Equals(taskPrice))
            {
                var priceValid = decimal.TryParse(taskPrice.Text, out decimal balance);
                if (!priceValid)
                    errorProvider.SetError(taskPrice, "Укажите число");
                else if (balance < 0)
                    errorProvider.SetError(taskPrice, "Баланс задачи не может быть отрицательным");
                else errorProvider.SetError(taskPrice,"");
            }
            else if (sender.Equals(taskRenderTime))
            {
                var timeValid = int.TryParse(taskRenderTime.Text, out int time);
                if (!timeValid)
                    errorProvider.SetError(taskRenderTime, "Укажите число");
                else if (time < 0)
                    errorProvider.SetError(taskRenderTime, "Времярендера задачи не может быть отрицательным");
                else errorProvider.SetError(taskRenderTime, "");
            }
            else if (sender.Equals(taskProject))
            {
                errorProvider.SetError(taskProject,
                    taskProject.SelectedItem == null ? "Укажите проект, которому принадлежит задача" : "");
            }
            else if (sender.Equals(taskSoftware))
            {
                errorProvider.SetError(taskSoftware,
                    taskSoftware.SelectedItem == null ? "Укажите софт, который использутся для рендера задачи" : "");
            }
            else if (sender.Equals(taskDesc))
            {
                errorProvider.SetError(taskDesc,
                    taskDesc.Text.Length > 5000 ? "Описание задачи не может содержать больше 5000 символов" : "");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (var control in fileds)
            {
                if (errorProvider.GetError(control) != "")
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            if (task == null)
            {
                task = new RenderTask();
            }
            
            task.Name = taskName.Text;
            task.Price = decimal.Parse(taskPrice.Text);
            task.RenderTime = int.Parse(taskRenderTime.Text);
            task.StartTime = taskStartDate.Value;
            task.Project = (Project)taskProject.SelectedItem;
            task.Software = (Software)taskSoftware.SelectedItem;
            task.Description = taskDesc.Text;
            
            db.RenderTasks.AddOrUpdate(task);
            db.SaveChanges();
            
        }
    }
}