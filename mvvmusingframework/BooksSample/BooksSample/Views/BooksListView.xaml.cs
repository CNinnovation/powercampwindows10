using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BooksSample.Views
{
    public sealed partial class BooksListView : UserControl
    {
        public BooksListView()
        {
            this.InitializeComponent();
            ViewModel = (Application.Current as App).Container.GetService<BooksListViewModel>();
        }

        public BooksListViewModel ViewModel { get; }
    }
}
