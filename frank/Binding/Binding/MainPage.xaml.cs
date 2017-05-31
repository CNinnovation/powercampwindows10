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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Binding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GetBooksService bookService = new GetBooksService();
        public MainPage()
        {
            this.InitializeComponent();
            bookService.AddBook(new Book("World of Bacon","Hans Wurst","Meatpress",1977));
            bookService.AddBook(new Book("Fall in love with a Sausage", "Hans Wurst", "Meatpress", 1995));
            this.DataContext = this;
        }

        public void  VisibilityConverter()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lsvBooks.Items.Add(bookService.GetBooks()[0].Title);
            lsvBooks.Items.Add(bookService.GetBooks()[1].Title);
        }
    }
}
