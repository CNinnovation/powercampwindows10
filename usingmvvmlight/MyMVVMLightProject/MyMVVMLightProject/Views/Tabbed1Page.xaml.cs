using MyMVVMLightProject.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MyMVVMLightProject.Views
{
    public sealed partial class Tabbed1Page : Page
    {
        private Tabbed1ViewModel ViewModel
        {
            get { return DataContext as Tabbed1ViewModel; }
        }

        public Tabbed1Page()
        {
            InitializeComponent();
        }
    }
}
