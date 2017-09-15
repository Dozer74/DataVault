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
            /*var projects = new[]
            {
                new Project {Name = "Call of duty", User = users[0]},
                new Project {Name = "Project X", User = users[0]},
                new Project {Name = "Project X 2", User = users[0]},

                new Project {Name = "Тест", User = users[1]},
                new Project {Name = "Видео", User = users[1]},
                new Project {Name = "HD Видео", User = users[1]},

                new Project {Name = "Котик 2017", Description = "Рендерим кота", User = users[2]},
                new Project {Name = "Котик 2", Description = "Мой кот", User = users[2]},
                new Project {Name = "Пес", Description = "А теперь рендерим собачку", User = users[2]},

                new Project {Name = "Avangers", User = users[3]},
                new Project {Name = "Avengers 2", User = users[3]},
                new Project {Name = "Avengers 3", User = users[3]},

                new Project {Name = "Batman", User = users[4]},
                new Project {Name = "Batman Return", User = users[4]},
                new Project {Name = "Batman Back", User = users[4]},

                new Project {Name = "Сумерки", User = users[5]},
                new Project {Name = "Автопилот", User = users[5]},

                new Project {Name = "Российская комадия", Description = "Очень смешная (нет)", User = users[6]},
                new Project {Name = "Ещё одна российская комадия", Description = "Тоже смешная", User = users[6]},
            };*/

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