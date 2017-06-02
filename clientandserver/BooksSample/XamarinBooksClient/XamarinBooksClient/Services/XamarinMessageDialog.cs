using System;
using System.Collections.Generic;
using System.Text;
using BooksLib.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBooksClient.Services
{
    public class PageService
    {
        public Page Page { get; set; }
    }

    public class XamarinMessageDialog : IMessageService
    {
        private readonly PageService _pageService;
        public XamarinMessageDialog(PageService pageService)
        {
            _pageService = pageService;
        }

        public Task ShowMessageAsync(string message)
        {
            _pageService.Page.DisplayAlert("Message", message, "Cancel");
            return Task.CompletedTask;
        }
    }
}
