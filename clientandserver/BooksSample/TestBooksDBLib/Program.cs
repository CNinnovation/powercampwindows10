using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServerBooksLib.Services;
using System;
using System.Linq;
using ServerBooksLib.Models;

namespace TestBooksDBLib
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();

            CreateADatabase();
            // CreateRecords();
            // QueryDemo();
            UpdateDemo();
            Console.ReadLine();
        }

        private static void UpdateDemo()
        {
            var context = Container.GetService<BooksContext>();
            var book = context.Books.Where(b => b.Title.StartsWith("Pro")).First();
            book.Title = "Professional C# 6 and .NET Core 1.0";
            int changed = context.SaveChanges();
            Console.WriteLine(changed);
        }

        private static void QueryDemo()
        {
            var context = Container.GetService<BooksContext>();
            var q = context.Books.Where(b => b.Publisher == "Wrox Press");


            foreach (var b in q)
            {
                Console.WriteLine($"{b.Title} {b.Publisher}");
            }
        }

        private static void CreateRecords()
        {
            var context = Container.GetService<BooksContext>();

            context.Books.Add(new Book { Title = "Professional C# 6", Publisher = "Wrox Press" });
            context.Books.Add(new Book { Title = "Enterprise Services", Publisher = "AWL" });
            context.Books.Add(new Book { Title = "Beginning Visual C# 2010", Publisher = "Wrox Press" });

            int recordschanged = context.SaveChanges();
            Console.WriteLine($"changed {recordschanged} records");

        }

        private static void CreateADatabase()
        {
            var context = Container.GetService<BooksContext>();

            bool created = context.Database.EnsureCreated();
        }

        static void RegisterServices()
        {
            const string ConnectionString = @"server=(localdb)\MSSQLLocalDb;database=Books;trusted_connection=true";
            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options =>
                options.UseSqlServer(ConnectionString));

            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}