using System;
using System.Collections.Generic;
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
using lab03.Services;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace lab03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly BooksService _bs = new BooksService();
        public IEnumerable<CBook> bookList;




        public CBook selectedBook
        {
            get { return (CBook)GetValue(selectedBookProperty); }
            set { SetValue(selectedBookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedBook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedBookProperty =
            DependencyProperty.Register("selectedBook", typeof(CBook), typeof(MainPage), new PropertyMetadata(0));




        public MainPage()
        {
            this.InitializeComponent();
            
            bookList = new ObservableCollection<CBook>(_bs.getBookList());
            selectedBook = bookList.First();
            this.DataContext = this;   //bookList;


        }

        //private void OnChangeBook(object sender, SelectionChangedEventArgs e)
        //{
        //    selectedBook = (CBook)listbox1.SelectedItem;
        //}
    }
}
