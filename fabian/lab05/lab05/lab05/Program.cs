using lab05.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab05
{
    class Program
    {
        const string ConnectionString = @"server=(localdb)\MSSQLLocalDb;database=Books;trusted_connection=true";
        public static IServiceProvider Container { get; private set; }



        static void Main(string[] args)
        {
            registerServices();
            string s;

            Console.WriteLine("a = db fuellen\nb = autor und titel anzeigen\nc = autor updaten");

            do
            {


                s = Console.ReadLine();

                createDB();

                switch (s)
                {
                    // db füllen
                    case "a":
                        fuellen();
                        break;
                    // daten aus db holen
                    case "b":
                        abrufen();
                        break;
                    // daten updaten
                    case "c":
                        update();
                        break;

                    default:
                        break;
                }

                Console.WriteLine("naechster befehl");
            } while (s != "x");

            Console.ReadLine();

        }

        private static void update()
        {
            var db = Container.GetService<BooksContext>();


            Console.WriteLine("author like: ");
            string s = Console.ReadLine();

            var books = db.books.Where(book => book.author.Contains(s));

            foreach (var book in books)
            {
                Console.WriteLine($"Current author: {book.author}\nNew author:");
                book.author = Console.ReadLine();
            }

            db.SaveChanges();
        }

        private static void abrufen()
        {
            var db = Container.GetService<BooksContext>();

            var books = db.books.Where(element => element.author.Any());
            foreach (var book in books)
            {
                Console.WriteLine($"{book.author}, {book.title}");
            }
        }

        private static void createDB()
        {
            var db = Container.GetService<BooksContext>();

            db.Database.EnsureCreated();
        }

        private static void fuellen()
        {
            var db = Container.GetService<BooksContext>();

            db.books.Add(new CBook {/* bookId = 1,*/ author = "Timmys Dad", title = "This is where I'd put my trophy!", publisher = "Dinkleberg" });
            db.books.Add(new CBook {/* bookId = 2,*/ author = "Cosmo", title = "Kaesekuchen", publisher = "Dinkleberg" });
            db.books.Add(new CBook {/* bookId = 3,*/ author = "Wanda", title = "Marmorkuchen", publisher = "Dinkleberg" });
            db.books.Add(new CBook {/* bookId = 4,*/ author = "Dinkleberg", title = "Schwarzwaelder Kirschtorte", publisher = "Dinkleberg" });

            db.SaveChanges();
            Console.WriteLine("created new items");
        }

        private static void registerServices()
        {
            var services = new ServiceCollection();
            //var options = new DbContextOptionsBuilder();
            //options.UseSqlServer(ConnectionString);
            services.AddDbContext<BooksContext>(options => options.UseSqlServer(ConnectionString));

            Container = services.BuildServiceProvider();
        }
    }
}
