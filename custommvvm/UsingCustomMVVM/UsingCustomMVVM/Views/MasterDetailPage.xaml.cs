using UsingCustomMVVM.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UsingCustomMVVM.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        public MasterDetailViewModel ViewModel { get; } = new MasterDetailViewModel();
        public MasterDetailPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }
    }
}
