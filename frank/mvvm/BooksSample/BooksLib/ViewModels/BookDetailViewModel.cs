using BooksLib.Services;
using TheBestMVVMFrameworkInTown;

namespace BooksLib.ViewModels
{
    public class BookDetailViewModel : ViewModelBase
    {
        private readonly ISelectedBookService _selectedBookService;
        public BookDetailViewModel(ISelectedBookService selectedBookService)
        {
            _selectedBookService = selectedBookService;
        }

        public ISelectedBookService SelectedBookService => _selectedBookService;
    }
}
