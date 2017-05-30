using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class CBook : CBindableBase
    {
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string title { get; set; }

        public CBook()
        {
            author = "Schreiberling";
            title = "DAS Buch";
        }
        public CBook(string _author, string _title)
        {
            author = _author;
            title = _title;
        }
    }
}
