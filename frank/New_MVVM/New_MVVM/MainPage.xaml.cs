using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using New_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace New_MVVM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
            Messenger.Default.Register<ShowMessageDialog>(this, (action) => ReceiveMessage(action));
        }

        private async void ReceiveMessage(ShowMessageDialog action)
        {
            DialogService dialogService = new DialogService();
            await dialogService.ShowMessage(action.Message, "Beispiel Universal App");
        }
    }
}
