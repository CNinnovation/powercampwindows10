using MyMVVMLightProject.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMVVMLightProject.Views
{
    public sealed partial class MasterDetail1Page : Page
    {
        private MasterDetail1ViewModel ViewModel
        {
            get { return DataContext as MasterDetail1ViewModel; }
        }

        public MasterDetail1Page()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadDataAsync(WindowStates.CurrentState);
        }
    }
}
