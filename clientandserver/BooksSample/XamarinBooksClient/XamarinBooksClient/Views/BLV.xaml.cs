using BooksLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBooksClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BLV : ContentView
	{
		public BLV ()
		{
			InitializeComponent ();
            ViewModel = (Application.Current as App).Container.GetService<BooksListViewModel>();
            this.BindingContext = this;
            booksListView.ItemsSource = ViewModel.Books;
        }

         public BooksListViewModel ViewModel { get; }
    }
}