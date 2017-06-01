using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new BooksContext())
            {

                // var context = new BooksContext();

                // string t = context.Database.Connection.ConnectionString;
                
                // Neue DB anlegen
                var book1 = new Books { BookID = 1, Author = "Hans Wurst", Title = "Dreams of a Butcher", Publisher = "Meat Press", Year = 1986 };
                db.Books.Add(book1);
                var book2 = new Books { BookID = 2, Author = "Hans Wurst", Title = "Years spent with a Pork", Publisher = "Meat Press", Year = 1997 };
                db.Books.Add(book2);
                var book3 = new Books { BookID = 3, Author = "Hans Wurst", Title = "Nothing else then Flesh", Publisher = "Meat Press", Year = 1969 };
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
            public BooksContext():base(@"data source=(localdb)\MSSQLLocalDb;initial catalog=Books;trusted_connection=true;")
            {

            }
            public DbSet<Books> Books { get; set; }
        }

    }
}
