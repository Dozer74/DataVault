using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataVault.DataModels;

namespace DataVault.Forms.Users
{
    public partial class AddEditUserForm : Form
    {
        private readonly Control[] fileds;
        private User user;

        public AddEditUserForm(User user = null)
        {
            InitializeComponent();
            this.user = user;
            if (user != null)
            {
                userName.Text = user.Name;
                userBalance.Text = user.Balance.ToString();
                userMail.Text = user.Email;
                btnOk.Text = "Обновить";
                Text = "Редактирование пользователя";
            }

            fileds = new Control[] {userName, userMail, userBalance};

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
            if (sender.Equals(userName))
            {
                if (userName.Text.Length < 1 || userName.Text.Length > 200)
                    errorProvider.SetError(userName, "Имя пользователя должно содержать от 1 до 200 символов");
                else errorProvider.SetError(userName, "");
            }
            else if (sender.Equals(userMail))
            {
                if (!IsValidEmail(userMail.Text))
                    errorProvider.SetError(userMail, "Email введен в некорректном формате");
                else if (userMail.Text.Length > 250)
                    errorProvider.SetError(userMail, "Email должен содержать не более 250 символов");
                else errorProvider.SetError(userMail, "");
            }
            else if (sender.Equals(userBalance))
            {
                var balanceValid = decimal.TryParse(userBalance.Text, out decimal balance);
                if (!balanceValid)
                    errorProvider.SetError(userBalance, "Укажите число");
                else if (balance < 0)
                    errorProvider.SetError(userBalance, "Баланс пользователя не может быть отрицательным");
                else errorProvider.SetError(userBalance,"");
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

            if (user == null)
            {
                user = new User();
            }

            user.Balance = decimal.Parse(userBalance.Text);
            user.Email = userMail.Text;
            user.Name = userName.Text;

            using (var db = new RenderFarm())
            {
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
            }
        }
    }
}