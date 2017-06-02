using BooksLib.Services;
using BooksLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinBooksClient.Services;

namespace XamarinBooksClient
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            RegisterServices();

			MainPage = new XamarinBooksClient.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
           
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<PageService>();
            services.AddSingleton<IMessageService, XamarinMessageDialog>();
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
