using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace BooksSample.Views
{
    public sealed partial class BookDetailView : UserControl
    {
        public BookDetailView()
        {
            this.InitializeComponent();
            ViewModel = (Application.Current as App).Container.GetService<BookDetailViewModel>();
            this.DataContext = this;
        }

        public BookDetailViewModel ViewModel { get; }
    }
}
