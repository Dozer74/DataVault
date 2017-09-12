using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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
