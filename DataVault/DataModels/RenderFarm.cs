namespace DataVault.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RenderFarm : DbContext
    {
        public RenderFarm()
            : base("name=RenderFarm")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RenderFarm>());
        }

        public virtual DbSet<GPU> Gpus { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<RenderTask> RenderTasks { get; set; }
        public virtual DbSet<SoftwareDeveloper> SoftwareDevelopers { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
