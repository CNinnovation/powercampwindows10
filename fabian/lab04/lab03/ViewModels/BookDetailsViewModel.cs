using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab03.Services;

namespace lab03.ViewModels
{
    class BookDetailsViewModel
    {
        private ISelectedBookService _selectedBookService;

        public BookDetailsViewModel(ISelectedBookService selectedBookService)
        {
            _selectedBookService = selectedBookService;
        }

        //public CBook selectedBook()
        //{
        //    return _selectedBookService.selectedBook;
        //}

        public ISelectedBookService SelectedbookService()
        {
            return _selectedBookService;
        }
    }
}
