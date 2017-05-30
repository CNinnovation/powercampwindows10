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

namespace EllipseButton
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Book> myBookList = new List<Book>();
        public MainPage()
        {
            this.InitializeComponent();
            
            myBookList.Add(new Book{Author = "Hans Wurst",Title = "Dreams of a butcher",Publisher = "Meatpress",Year = 1969});
            myBookList.Add(new Book { Author = "Hans Wurst", Title = "Years spent with Porks", Publisher = "Meatpress", Year = 1974 });
            myBookList.Add(new Book { Author = "Hans Wurst", Title = "Nothing else like Flesh", Publisher = "Meatpress", Year = 1986 });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button1.Content = String.Join("-", (string)myBookList[0].Title, (string)myBookList[0].Author, (string)myBookList[0].Publisher);
            Button2.Content = String.Join("-", (string)myBookList[1].Title, (string)myBookList[1].Author, (string)myBookList[1].Publisher);
            Button3.Content = String.Join("-", (string)myBookList[2].Title, (string)myBookList[2].Author, (string)myBookList[2].Publisher);
        }
    }
}
