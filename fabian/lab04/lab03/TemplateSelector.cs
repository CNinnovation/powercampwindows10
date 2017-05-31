using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace lab03
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate template1 { get; set; }
        public DataTemplate template2 { get; set; }

        public TemplateSelector() { }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DataTemplate selected = null;

            if (item is CBook book)
            {
                if (book.author == "Autor2")
                    selected = template1;
                else
                    selected = template2;
                
            }
            return selected;
        }
    }
}
