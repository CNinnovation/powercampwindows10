using UsingCustomMVVM.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UsingCustomMVVM.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
