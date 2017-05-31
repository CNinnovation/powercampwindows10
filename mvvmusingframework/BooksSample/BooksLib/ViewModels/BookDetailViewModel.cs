using BooksLib.Services;
using Prism.Mvvm;

namespace BooksLib.ViewModels
{
    public class BookDetailViewModel : BindableBase
    {
        private readonly ISelectedBookService _selectedBookService;
        public BookDetailViewModel(ISelectedBookService selectedBookService)
        {
            _selectedBookService = selectedBookService;
        }

        public ISelectedBookService SelectedBookService => _selectedBookService;
    }
}
