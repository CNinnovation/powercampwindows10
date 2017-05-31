using UsingCustomMVVM.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UsingCustomMVVM.Views
{
    public sealed partial class TabbedPage : Page
    {
        public TabbedViewModel ViewModel { get; } = new TabbedViewModel();
        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
