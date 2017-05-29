using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Containers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContainersPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<string> _items = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChange( string name )
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem;  }
            set { _selectedItem = value;  }
        }

        public ObservableCollection<string> Items
        {
            get { return _items;  }
            set { _items = value;  }
        }

        private SplitViewDisplayMode _svdm = SplitViewDisplayMode.Inline;
        public SplitViewDisplayMode SplitViewDisplayMode
        {
            get { return _svdm; }
            set { _svdm = value; NotifyPropertyChange("SplitViewDisplayMode"); }
        }

        public ContainersPage()
        {
            this.InitializeComponent();

            this.DataContext = this;

            Items.Add("Item1");
            Items.Add("Item2");

            NotifyPropertyChange("Items");
        }
    }
}
