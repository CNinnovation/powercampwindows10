using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03.Services
{
    public interface ISelectedBookService : INotifyPropertyChanged

    {
        CBook selectedBook { get; set; }
    }

    class SelectedBookService : CBindableBase ,ISelectedBookService
    {


        private CBook _selectedBook;

        public CBook selectedBook
        {
            get { return _selectedBook; }
            set { setProp(ref _selectedBook, value); }
        }

    }
}
