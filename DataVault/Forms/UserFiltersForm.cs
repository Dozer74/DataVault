using System;
using System.Globalization;
using System.Windows.Forms;

namespace DataVault.Forms
{
    public partial class UserFiltersForm : Form
    {
        public static string FilterName { get; private set; } = "";
        public static string FilterEmail { get; private set; } = "";
        public static decimal FilterBalanceFrom { get; private set; } = -1m;
        public static decimal FilterBalanceTo { get; private set; } = -1m;
        public static bool IsBalanceFilterEnabled => FilterBalanceFrom != -1m || FilterBalanceTo != -1m;

        public UserFiltersForm()
        {
            InitializeComponent();
            userName.Text = FilterName;
            userMail.Text = FilterEmail;

            if (FilterBalanceFrom > -1m)
                balanceFrom.Text = FilterBalanceFrom.ToString();

            if (FilterBalanceTo > -1m)
                balanceTo.Text = FilterBalanceTo.ToString();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            var bFrom = balanceFrom.Text != ""
                ? Decimal.Parse(balanceFrom.Text, NumberStyles.Any)
                : -1m;

            var bTo = balanceTo.Text != ""
                ? Decimal.Parse(balanceTo.Text, NumberStyles.Any)
                : -1m;

            if (bFrom > 0 && bTo >0 && bFrom > bTo)
            
            {
                var buf = bFrom;
                bFrom = bTo;
                bTo = buf;
            }
            

            if (sender.Equals(btnOk))
            {
                FilterName = userName.Text.ToLower();
                FilterEmail = userMail.Text.ToLower();
                FilterBalanceFrom = bFrom;
                FilterBalanceTo = bTo;
            }
            else if (sender.Equals(btnIgnore))
            {
                FilterName = FilterEmail = "";
                FilterBalanceFrom = FilterBalanceTo = -1m;
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
    }
}