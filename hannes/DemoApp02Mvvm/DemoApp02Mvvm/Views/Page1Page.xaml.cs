using Prism.Events;
using Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DemoApp02Mvvm.Views
{
    public sealed partial class Page1Page : Page, INotifyPropertyChanged
    {
        public Page1Page()
        {
            InitializeComponent();

            IEventAggregator ea = (Application.Current as App).Services.GetService( typeof( IEventAggregator ) ) as IEventAggregator;

            DataContext = new DeveloperListViewModel( new DeveloperService(), ea );
        }

        public DeveloperListViewModel ViewModel
        {
            get => DataContext as DeveloperListViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
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
