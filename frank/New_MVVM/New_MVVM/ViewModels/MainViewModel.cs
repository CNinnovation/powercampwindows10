using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_MVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            HalloWurst = IsInDesignMode ? "Läuft im Design Mode" : "Läuft im Laufzeit Mode";
        }
        private string _halloWurst;
        private RelayCommand _showMessageCommand;
        public string HalloWurst
        {
            get { return _halloWurst; }
            set { Set(() => HalloWurst, ref _halloWurst, value); }
        }
        // public RelayCommand ShowMessageCommand { get; set; }

        public RelayCommand ShowMessageCommand
        {
            set => _showMessageCommand ?? (_showMessageCommand = new RelayCommand(ShowMessage));
        }

        private object ShowMessage()
        {
            var msg = new ShowMessageDialog { Message = "Hallo Wurst" };
            Messenger.Default.Send<ShowMessageDialog>(msg);
            return null;
        }
    }
}
