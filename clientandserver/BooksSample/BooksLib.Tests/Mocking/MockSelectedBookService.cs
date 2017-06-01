using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using BooksLib.Models;
using System.ComponentModel;

namespace BooksLib.Tests.Mocking
{
    public class MockSelectedBookService : ISelectedBookService
    {
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBook)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
