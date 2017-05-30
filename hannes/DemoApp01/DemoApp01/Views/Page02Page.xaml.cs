using DemoApp01.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace DemoApp01.Views
{
    public sealed partial class Page02Page : Page, INotifyPropertyChanged
    {
        public Page02Page()
        {
            InitializeComponent();

            this.DataContext = this;

            _developers.Add(new Developer() { Name = "Christian Nagel", EMail = "christian.nagel@cninnovation.com" });
            _developers.Add(new Developer() { Name = "Johannes Maly", EMail = "johannes.maly@chello.at" });

            AddDeveloper = new CommandHandler(new Action(DoAddDeveloper), true);

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

        private Developer _selectedDeveloper;
        public Developer SelectedDeveloper
        {
            get => _selectedDeveloper;
            set => SetProperty(ref _selectedDeveloper, value );
        }

        private ObservableCollection<Developer> _developers = new ObservableCollection<Developer>();

        public ObservableCollection<Developer> Developers
        {
            get => _developers;
            set => SetProperty(ref _developers, value);
        }

        private string _developerName;
        public string DeveloperName
        {
            get => _developerName;
            set => SetProperty(ref _developerName, value);
        }

        private string _developerEMail;
        public string DeveloperEMail
        {
            get => _developerEMail;
            set => SetProperty(ref _developerEMail, value);
        }

        private string _developerPassword;
        public string DeveloperPassword
        {
            get => _developerPassword;
            set => SetProperty(ref _developerPassword, value);
        }

        private DateTimeOffset _developerBirthDay;
        public DateTimeOffset DeveloperBirthDay
        {
            get => _developerBirthDay;
            set => SetProperty(ref _developerBirthDay, value);
        }

        private ICommand _addDeveloper;

        public ICommand AddDeveloper
        {
            get => _addDeveloper;
            set => SetProperty( ref _addDeveloper, value );
        }

        public async void DoAddDeveloper()
        {
            if ( !string.IsNullOrWhiteSpace( DeveloperName ))
            {
                var d = new Developer() { Name=DeveloperName, EMail=DeveloperEMail, Password=DeveloperPassword, BirthDay=DeveloperBirthDay.Date };

                Developers.Add(d);
            }
            else
            {
                var mb = new MessageDialog("Please enter a developer name");
                await mb.ShowAsync();
            }
        }
    }
}
