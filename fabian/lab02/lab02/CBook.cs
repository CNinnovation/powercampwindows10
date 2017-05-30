using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class CBook
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public CBook()
        {
            ID = 10;
            title = "Buch";
            author = "Schreiberling";
        }

        public CBook(int _id, string _title, string _author)
        {
            ID = _id;
            title = _title;
            author = _author;
        }
    }
}
