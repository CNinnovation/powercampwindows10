using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyFirstUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            button1.Width = 500;
            var gradientStops = new GradientStopCollection();
            gradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 0 });
            gradientStops.Add(new GradientStop { Color = Colors.Red, Offset=1 });
            var myBrush = new LinearGradientBrush(gradientStops, 90);

            Grid.SetRow(button1, 0);

            button1.Background = myBrush;
        }

        public int Simple1 { get; set; }

        private int simple2;

        public int Simple2
        {
            get { return simple2; }
            set { simple2 = value; }
        }



        public int MyDependency
        {
            get { return (int)GetValue(MyDependencyProperty); }
            set { SetValue(MyDependencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDependency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDependencyProperty =
            DependencyProperty.Register("MyDependency", typeof(int), typeof(MainPage), new PropertyMetadata(0));




    }
}
