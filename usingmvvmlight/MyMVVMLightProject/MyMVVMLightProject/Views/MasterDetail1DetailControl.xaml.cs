using MyMVVMLightProject.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyMVVMLightProject.Views
{
    public sealed partial class MasterDetail1DetailControl : UserControl
    {
        public SampleModel MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleModel; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem",typeof(SampleModel),typeof(MasterDetail1DetailControl),new PropertyMetadata(null));

        public MasterDetail1DetailControl()
        {
            InitializeComponent();
        }
    }
}
