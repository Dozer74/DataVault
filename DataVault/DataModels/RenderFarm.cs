namespace DataVault.DataModels
{
    using System.Data.Entity;

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
            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .IsOptional();
        }
    }
}