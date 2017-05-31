using BooksLib.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BooksSample.Utilities
{
    public class BookTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultBookTemplate { get; set; }
        public DataTemplate WroxBookTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            DataTemplate selectedTemplate = null;
            if (item is Book book)
            {
                switch (book.Publisher)
                {
                    case "Wrox Press":
                        selectedTemplate = WroxBookTemplate;
                        break;
                    default:
                        selectedTemplate = DefaultBookTemplate;
                        break;
                }
            }

            return selectedTemplate;
        }
    }
}
