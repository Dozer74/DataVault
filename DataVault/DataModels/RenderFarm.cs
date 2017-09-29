using System;
using System.Collections;
using System.IO;
using System.Linq;

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

            modelBuilder.Entity<RenderTask>()
                .Property(p => p.Description)
                .IsOptional();

            modelBuilder.Entity<Node>()
                .Property(p => p.Description)
                .IsOptional();

            // generate stored procedures
            modelBuilder.Entity<User>().MapToStoredProcedures();
            modelBuilder.Entity<Project>().MapToStoredProcedures();
            modelBuilder.Entity<Node>().MapToStoredProcedures();
            modelBuilder.Entity<GpuManufactor>().MapToStoredProcedures();
            modelBuilder.Entity<GPU>().MapToStoredProcedures();
            modelBuilder.Entity<RenderTask>().MapToStoredProcedures();
            modelBuilder.Entity<Software>().MapToStoredProcedures();
            modelBuilder.Entity<SoftwareDeveloper>().MapToStoredProcedures();
        }
    }

    public class DbInitializer : DropCreateDatabaseAlways<RenderFarm>
    {
        readonly Random rand = new Random(42);

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        protected override void Seed(RenderFarm context)
        {
            base.Seed(context);


            var emails = File.ReadAllLines("email.txt");
            var users = File.ReadAllLines("users.txt")
                .Select(p => new User
                    {
                        Name = p,
                        Balance = rand.Next(100, 10000),
                        Email = emails[rand.Next(emails.Length)]
                    }
                ).ToArray();

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

                new GPU {Model = "R9 280X", Manufactor = gpuManufactors[1], Passmark = Int16.MaxValue - 550},
                new GPU {Model = "R9 280", Manufactor = gpuManufactors[1], Passmark = 28700},
                new GPU {Model = "R9 FURY X", Manufactor = gpuManufactors[1], Passmark = Int16.MaxValue},
                new GPU {Model = "R7 280", Manufactor = gpuManufactors[1], Passmark = 26500},
                new GPU {Model = "R7 270", Manufactor = gpuManufactors[1], Passmark = 25000},
                new GPU {Model = "R7 250", Manufactor = gpuManufactors[1], Passmark = 23500},

                new GPU {Model = "RX 460", Manufactor = gpuManufactors[3], Passmark = 26500 - 350},
                new GPU {Model = "RX 370", Manufactor = gpuManufactors[3], Passmark = 25000 - 350},
                new GPU {Model = "RX NANO", Manufactor = gpuManufactors[3], Passmark = 23500 - 350},


                new GPU {Model = "C4Q", Manufactor = gpuManufactors[3], Passmark = 18350},
                new GPU {Model = "C4V", Manufactor = gpuManufactors[3], Passmark = 17250},
                new GPU {Model = "C2Q", Manufactor = gpuManufactors[3], Passmark = 16500},
            };

            var nodes = new Node[100];
            for (int i = 0; i < 100; i++)
            {
                nodes[i] = new Node
                {
                    Name = $"SLAVE-{i:000}",
                    GpuCount = (short) ((i / 10) + 1),
                    Gpu = gpus[i % gpus.Length]
                };
            }

            var softwareDevelopers = new[]
            {
                new SoftwareDeveloper {Name = "Autodesk 3DS Max"},
                new SoftwareDeveloper {Name = "Cinema"},
                new SoftwareDeveloper {Name = "Blender"}
            };

            var software = new[]
            {
                new Software {SoftwareDeveloper = softwareDevelopers[0], Version = "2017"},
                new Software {SoftwareDeveloper = softwareDevelopers[0], Version = "2016"},
                new Software {SoftwareDeveloper = softwareDevelopers[0], Version = "2015"},
                new Software {SoftwareDeveloper = softwareDevelopers[0], Version = "2014"},

                new Software {SoftwareDeveloper = softwareDevelopers[1], Version = "R 18"},
                new Software {SoftwareDeveloper = softwareDevelopers[1], Version = "R 17"},

                new Software {SoftwareDeveloper = softwareDevelopers[2], Version = "Community"},
                new Software {SoftwareDeveloper = softwareDevelopers[2], Version = "2015"},
            };

            var projects = File.ReadAllLines("projects.txt")
                .Select(p => new Project {Name = p, User = users[rand.Next(users.Length)]}).ToArray();

            var films = File.ReadAllLines("films2.txt");
            var descs = File.ReadAllLines("desc.txt");
            var renderTasks = new RenderTask[films.Length];

            for (int i = 0; i < films.Length; i++)
            {
                renderTasks[i] = new RenderTask
                {
                    Name = films[i],
                    Description = descs[i],
                    Project = projects[rand.Next(projects.Length)],
                    Software = software[rand.Next(software.Length)],
                    Price = rand.Next(100, 5000),
                    RenderTime = rand.Next(10, 2000),
                    Nodes = Enumerable.Range(0, rand.Next(1, 10)).Select(n => nodes[rand.Next(nodes.Length)]).ToList(),
                    StartTime = RandomDay()
                };
            }
            
            context.Users.AddRange(users);
            context.GpuManufactors.AddRange(gpuManufactors);
            context.Gpus.AddRange(gpus);
            context.Nodes.AddRange(nodes);
            context.Projects.AddRange(projects);
            context.SoftwareDevelopers.AddRange(softwareDevelopers);
            context.Softwares.AddRange(software);
            context.RenderTasks.AddRange(renderTasks);
        }
    }
}