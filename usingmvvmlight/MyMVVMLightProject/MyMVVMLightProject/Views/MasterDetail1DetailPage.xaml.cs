using MyMVVMLightProject.Models;
using MyMVVMLightProject.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMVVMLightProject.Views
{
    public sealed partial class MasterDetail1DetailPage : Page
    {
        private MasterDetail1DetailViewModel ViewModel
        {
            get { return DataContext as MasterDetail1DetailViewModel; }
        }

        public MasterDetail1DetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Item = e.Parameter as SampleModel;
        }
    }
}
