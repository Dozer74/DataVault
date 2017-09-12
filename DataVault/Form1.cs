using System;
using System.Windows.Forms;
using DataVault.DataModels;

namespace DataVault
{
    public partial class Form1 : Form
    {
        private RenderFarm dbContext;
        public Form1()
        {
            InitializeComponent();
            dbContext = new RenderFarm();

            ModelDiagram.Generate("RenderFarm.edmx");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbContext.Users.Add(new User {Name = "Alex", Email = "Alex@ya.ru", Balance = 5m});
            dbContext.SaveChanges();
        }
    }
}
