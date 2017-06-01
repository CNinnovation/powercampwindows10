using BooksLib.Models;
using System.ComponentModel;
using TheCoolestMVVM;

namespace BooksLib.Services
{
    public interface ISelectedBookService : INotifyPropertyChanged
    {
        Book SelectedBook { get; set; }
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
