using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace DemoApp01.Views
{
    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public sealed partial class Page01Page : Page, INotifyPropertyChanged
    {
        public Page01Page()
        {
            InitializeComponent();

            DataContext = this;

            DisplayModes.Add(SplitViewDisplayMode.Inline.ToString());
            DisplayModes.Add(SplitViewDisplayMode.Overlay.ToString());
            DisplayModes.Add(SplitViewDisplayMode.CompactInline.ToString());
            DisplayModes.Add(SplitViewDisplayMode.CompactOverlay.ToString());

            SelectedDisplayMode = SplitViewDisplayMode.Inline.ToString();

            ToogleIsPaneOpen = new CommandHandler( new Action( DoToogleIsPaneOpen ), true );
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

        private string _selectedDisplayMode = SplitViewDisplayMode.Inline.ToString();

        public string SelectedDisplayMode
        {
            get { return _selectedDisplayMode; }
            set
            {
                if ( Set( ref _selectedDisplayMode, value ) )
                {
                    if (_selectedDisplayMode == SplitViewDisplayMode.Inline.ToString())
                    {
                        DisplayMode = SplitViewDisplayMode.Inline;
                    }

                    else
                    if (_selectedDisplayMode == SplitViewDisplayMode.CompactInline.ToString())
                    {
                        DisplayMode = SplitViewDisplayMode.CompactInline;
                    }

                    else
                    if (_selectedDisplayMode == SplitViewDisplayMode.Overlay.ToString())
                    {
                        DisplayMode = SplitViewDisplayMode.Overlay;
                    }

                    else
                    if (_selectedDisplayMode == SplitViewDisplayMode.CompactOverlay.ToString())
                    {
                        DisplayMode = SplitViewDisplayMode.CompactOverlay;
                    }

                    IsPaneOpen = true;
                }
            }
        }

        private ObservableCollection< string > _displayModes = new ObservableCollection< string >();

        public ObservableCollection< string > DisplayModes
        {
            get { return _displayModes; }
            set { Set(ref _displayModes, value); }
        }

        private SplitViewDisplayMode _displayMode = SplitViewDisplayMode.Inline;

        public SplitViewDisplayMode DisplayMode
        {
            get { return _displayMode; }
            set { Set(ref _displayMode, value); }
        }

        private bool _isPaneOpen = true;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }

        private ICommand _toogleIsPaneOpen;

        public ICommand ToogleIsPaneOpen
        {
            get => _toogleIsPaneOpen;
            set => Set(ref _toogleIsPaneOpen, value);
        }

        public void DoToogleIsPaneOpen()
        {
            IsPaneOpen = !IsPaneOpen;
        }

    }
}
