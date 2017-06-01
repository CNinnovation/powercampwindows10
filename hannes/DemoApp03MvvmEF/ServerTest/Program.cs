using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServerModels;
using ServerServices;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ServerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();

            CreateDatabase();

            InsertDevelopers();

            SelectDevelopers();

            var context = Services.GetService<DbDeveloperContext>();

            IList<Developer> ld = context.Developers.ToList<Developer>();

            UpdateDeveloper(ld[0]);
        }

        static void CreateDatabase()
        {
            var context = Services.GetService< DbDeveloperContext >();

            bool created = context.Database.EnsureCreated();

            Console.WriteLine($"created {created}");
        }

        static void InsertDevelopers()
        {
            var context = Services.GetService< DbDeveloperContext>();

            int ir = context.Database.ExecuteSqlCommand("truncate table Developers;");

            for (int i = 1; i < 100; i++)
            {
                Developer d = new Developer();

                d.Name = $"Developer {i}";
                d.EMail = $"developer{i}@demo.com";

                context.Developers.Add(d);
            }

            int recordschanged = context.SaveChanges();

            Console.WriteLine($"changed {recordschanged} records");
        }

        static void SelectDevelopers()
        {
            var context = Services.GetService<DbDeveloperContext>();

            var recs = context.Developers.Where(d => d.Id > 0);
            foreach (var d in recs)
            {
                Console.WriteLine($"{d.Name}");
            }
        }

        static void UpdateDeveloper( Developer d )
        {
            var context = Services.GetService< DbDeveloperContext >();
            d.BirthDay = DateTime.Now.AddYears(-50);
            int changed = context.SaveChanges();
          //Console.WriteLine(changed);
        }

        static public IServiceProvider Services { get; private set; }

        static private void RegisterServices()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Developers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var services = new ServiceCollection();

            services.AddDbContext<DbDeveloperContext>(options => options.UseSqlServer(connectionString));

            Services = services.BuildServiceProvider();
        }

    }
}