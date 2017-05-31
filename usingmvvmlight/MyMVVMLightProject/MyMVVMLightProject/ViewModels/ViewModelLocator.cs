using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

using MyMVVMLightProject.Services;
using MyMVVMLightProject.Views;

namespace MyMVVMLightProject.ViewModels
{
    public class ViewModelLocator
    {
        NavigationServiceEx _navigationService = new NavigationServiceEx();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => _navigationService);
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<MasterDetail1ViewModel, MasterDetail1Page>();
            Register<MasterDetail1DetailViewModel, MasterDetail1DetailPage>();
            Register<Tabbed1ViewModel, Tabbed1Page>();
        }

        public Tabbed1ViewModel Tabbed1ViewModel => ServiceLocator.Current.GetInstance<Tabbed1ViewModel>();

        public MasterDetail1DetailViewModel MasterDetail1DetailViewModel => ServiceLocator.Current.GetInstance<MasterDetail1DetailViewModel>();

        public MasterDetail1ViewModel MasterDetail1ViewModel => ServiceLocator.Current.GetInstance<MasterDetail1ViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public void Register<VM, V>() where VM : class
        {
            SimpleIoc.Default.Register<VM>();
            _navigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
