using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBooksClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent ();

            //         ViewModel = (Application.Current as App).Container.GetService<BooksListViewModel>();
            //         this.DataContext = this;
        }

        // public BooksListViewModel ViewModel { get; }
    }
}
