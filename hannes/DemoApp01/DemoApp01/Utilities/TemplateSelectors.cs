using DemoApp01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DemoApp01.Utilities
{
    public class DeveloperTemplateSelector : DataTemplateSelector
    {
        public DeveloperTemplateSelector()
        {

        }
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate CSharpTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DataTemplate selectedTemplate = null;
            if (item is Developer dev)
            {
                selectedTemplate = dev.DevelopsCSharp ? CSharpTemplate : DefaultTemplate;
            }

            return selectedTemplate;
        }

    }
}
