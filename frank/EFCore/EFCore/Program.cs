using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new BooksContext())
            {
                bool created = db.Database.EnsureCreated();
                // var context = new BooksContext();

                // string t = context.Database.Connection.ConnectionString;
                
                // Neue DB anlegen
                var book1 = new Books { Author = "Hans Wurst", Title = "Dreams of a Butcher", Publisher = "Meat Press", Year = 1986 };
                db.Books.Add(book1);
                var book2 = new Books {  Author = "Hans Wurst", Title = "Years spent with a Pork", Publisher = "Meat Press", Year = 1997 };
                db.Books.Add(book2);
                var book3 = new Books { Author = "Hans Wurst", Title = "Nothing else then Flesh", Publisher = "Meat Press", Year = 1969 };
                db.Books.Add(book3);

                db.SaveChanges();

                var query = from b in db.Books orderby b.Title select b;

                Console.WriteLine("All books in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Title);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }

        public class BooksContext : DbContext
        {
            public BooksContext()
            {

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=BooksSample;trusted_connection=true");
            }

            public DbSet<Books> Books { get; set; }
        }

    }
}
