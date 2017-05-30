using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace BooksSample.UWPServices
{
    public class UWPMessageDialog : IMessageService
    {
        public Task ShowMessageAsync(string message) => new MessageDialog(message).ShowAsync().AsTask();
    }
}
