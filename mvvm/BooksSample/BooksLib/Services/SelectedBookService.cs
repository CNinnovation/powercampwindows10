using BooksLib.Models;
using System.ComponentModel;
using TheCoolestMVVM;

namespace BooksLib.Services
{
    public interface ISelectedBookService
    {
        Book SelectedBook { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
    public class SelectedBookService : BindableBase, ISelectedBookService
    {
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set => SetProperty(ref _selectedBook, value);
        }
    }
}
