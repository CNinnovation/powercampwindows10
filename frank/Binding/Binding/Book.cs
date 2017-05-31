using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
        public class Book : BindableBase
        {
            public Book(string title, string author, string publisher, int year)
            {
              Title = title;
              Author = author;
              Publisher = publisher;
              Year = year;
            }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public int Year { get; set; }
        }
   
}
