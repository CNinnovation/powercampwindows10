using BooksSample.Models;
using BooksSample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BooksSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly BooksService _booksService = new BooksService();
        private readonly ObservableCollection<Book> _books;
        //private Book _selectedBook;

        //public Book SelectedBook
        //{
        //    get { return _selectedBook; }
        //    set { _selectedBook = value; }
        //}

        public Book SelectedBook
        {
            get { return (Book)GetValue(SelectedBookProperty); }
            set { SetValue(SelectedBookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedBook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedBookProperty =
            DependencyProperty.Register("SelectedBook", typeof(Book), typeof(MainPage), new PropertyMetadata(null));


        public IEnumerable<Book> Books => _books;
        public MainPage()
        {
            this.InitializeComponent();
            _books = new ObservableCollection<Book>(_booksService.GetBooks());
            SelectedBook = _books.First();
            this.DataContext = this;
        }

        private void OnChangeBook(object sender, RoutedEventArgs e)
        {
            _books.First().Title = "Professional C# 7";
        }

        private void OnAddBook(object sender, RoutedEventArgs e)
        {
            _books.Add(new Book { Title = "Professional C# 7.x and .NET Core 2.0", Publisher = "Wrox Press", Authors = new string[] { "Christian Nagel" } });
        }
    }
}
