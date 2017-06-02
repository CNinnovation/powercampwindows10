using BooksLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;

namespace WPFBooksClient.Views
{
    /// <summary>
    /// Interaction logic for BooksListView.xaml
    /// </summary>
    public partial class BooksListView : UserControl
    {
        public BooksListView()
        {
            InitializeComponent();
            ViewModel = (Application.Current as App).Container.GetService<BooksListViewModel>();
            this.DataContext = this;
        }

        public BooksListViewModel ViewModel { get; }
    }
}
