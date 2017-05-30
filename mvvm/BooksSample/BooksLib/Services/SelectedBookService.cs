using BooksLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TheCoolestMVVM;

namespace BooksLib.Services
{
    public interface ISelectedBookService
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
