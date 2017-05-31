using Prism.Events;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DemoApp02Mvvm.Views
{
    public sealed partial class Page2Page : Page, INotifyPropertyChanged
    {
        public Page2Page()
        {
            InitializeComponent();

            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;

            IEventAggregator ea = (Application.Current as App).Services.GetService(typeof(IEventAggregator)) as IEventAggregator;

            DataContext = (Application.Current as App).Services.GetService(typeof(DeveloperDetailsViewModel)) as DeveloperDetailsViewModel;
        }

        public DeveloperDetailsViewModel ViewModel
        {
            get => DataContext as DeveloperDetailsViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
