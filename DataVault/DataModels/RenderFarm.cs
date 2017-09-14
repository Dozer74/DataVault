namespace DataVault.DataModels
{
    using System.Data.Entity;

    public partial class RenderFarm : DbContext
    {
        public RenderFarm()
            : base("name=RenderFarm")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public virtual DbSet<GPU> Gpus { get; set; }
        public virtual DbSet<GpuManufactor> GpuManufactors { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<RenderTask> RenderTasks { get; set; }
        public virtual DbSet<SoftwareDeveloper> SoftwareDevelopers { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.Description)
                .IsOptional();
        }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<RenderFarm>
    {
        protected override void Seed(RenderFarm context)
        {
            base.Seed(context);
            context.Users.AddRange(new[]
            {
                new User {Name = "FOX Inc.", Balance = 15000, Email = "foxArt@gmail.com"},
                new User {Name = "Петров", Balance = 10, Email = "petya@gmail.com"},
            });

            context.GpuManufactors.AddRange(new[]
            {
                new GpuManufactor {Name = "Nvidia"},
                new GpuManufactor {Name = "Radeon"}, 
            });
        }
    }
}