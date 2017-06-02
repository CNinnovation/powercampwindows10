using BooksLib.Services;
using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFBooksClient.WPFServices;

namespace WPFBooksClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
        }

        private void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMessageService, WPFMessageDialog>();
            // services.AddSingleton<IBooksService, BooksService>();
            services.AddSingleton<IBooksService, HttpBooksService>();
            services.AddSingleton<ISelectedBookService, SelectedBookService>();
            services.AddTransient<BooksListViewModel>();
            services.AddTransient<BookDetailViewModel>();
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
