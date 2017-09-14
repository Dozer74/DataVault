using System;

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

            var users = new[]
            {
                new User {Name = "FOX Inc.", Balance = 15000, Email = "foxArt@gmail.com"},
                new User {Name = "Петров", Balance = 10, Email = "petya@gmail.com"},
                new User {Name = "Иванов", Balance = 15, Email = "ivanov@ya.ru"},
                new User {Name = "Sony Pictures", Balance = 12120, Email = "support@sony.com"},
                new User {Name = "Warner Brothers", Balance = 25100, Email = "hello@vb.com"},
                new User {Name = "Мегамакс", Balance = 500, Email = "mm@mm.ru"},
                new User {Name = "Фонд кино", Balance = 1520, Email = "fond-kino@rambler.ru"},
            };

            var gpuManufactors = new[]
            {
                new GpuManufactor {Name = "Nvidia"},
                new GpuManufactor {Name = "Radeon"},
                new GpuManufactor {Name = "AMD (ATI)"},
                new GpuManufactor {Name = "His"}
            };

            var gpus = new[]
            {
                new GPU {Model = "GTX 1080 ti", Manufactor = gpuManufactors[0], Passmark = Int16.MaxValue},
                new GPU {Model = "GTX 1080", Manufactor = gpuManufactors[0], Passmark = 29000},
                new GPU {Model = "GTX 1070", Manufactor = gpuManufactors[0], Passmark = 28500},
                new GPU {Model = "GTX 1060", Manufactor = gpuManufactors[0], Passmark = 27000},
                new GPU {Model = "GT 980", Manufactor = gpuManufactors[0], Passmark = 26000},
                new GPU {Model = "GT 960", Manufactor = gpuManufactors[0], Passmark = 25000},
                new GPU {Model = "GT 950 ti", Manufactor = gpuManufactors[0], Passmark = 23000},
                new GPU {Model = "GT 940", Manufactor = gpuManufactors[0], Passmark = 20000},

                new GPU {Model = "R9 280X", Manufactor = gpuManufactors[1], Passmark = Int16.MaxValue-550},
                new GPU {Model = "R9 280", Manufactor = gpuManufactors[1], Passmark = 28700},
                new GPU {Model = "R9 FURY X", Manufactor = gpuManufactors[1], Passmark = Int16.MaxValue},
                new GPU {Model = "R7 280", Manufactor = gpuManufactors[1], Passmark = 26500},
                new GPU {Model = "R7 270", Manufactor = gpuManufactors[1], Passmark = 25000},
                new GPU {Model = "R7 250", Manufactor = gpuManufactors[1], Passmark = 23500},

                new GPU {Model = "RX 460", Manufactor = gpuManufactors[3], Passmark = 26500-350},
                new GPU {Model = "RX 370", Manufactor = gpuManufactors[3], Passmark = 25000-350},
                new GPU {Model = "RX NANO", Manufactor = gpuManufactors[3], Passmark = 23500-350},


                new GPU {Model = "C4Q", Manufactor = gpuManufactors[3], Passmark = 18350},
                new GPU {Model = "C4V", Manufactor = gpuManufactors[3], Passmark = 17250},
                new GPU {Model = "C2Q", Manufactor = gpuManufactors[3], Passmark = 16500},
            };


            context.Users.AddRange(users);
            context.GpuManufactors.AddRange(gpuManufactors);
            context.Gpus.AddRange(gpus);
        }
    }
}