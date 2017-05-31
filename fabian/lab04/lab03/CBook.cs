using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class CBook : CBindableBase
    {
        private string _author;

        public string author
        {
            get { return _author; }
            set { setProp(ref _author, value); }
        }

        private string _title;

        public string title
        {
            get { return _title; }
            set { setProp(ref _title, value); }
        }


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
