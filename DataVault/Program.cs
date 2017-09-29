using System;
using System.Linq;
using System.Windows.Forms;
using DataVault.DataModels;
using DataVault.Forms;
using DataVault.Forms.RenderTasks;
using DataVault.Forms.Users;

namespace DataVault
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
