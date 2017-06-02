using Microsoft.Extensions.DependencyInjection.Extensions;
using Interfaces;
using Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ViewModels.Events;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DeveloperListViewModel : BindableBase
    {
        private IEventAggregator _ea;

        private IDeveloperService _developerService;

        public DeveloperListViewModel(IDeveloperService developerService, IEventAggregator ea)
        {
            _developerService = developerService;
            _ea = ea;

            Task.Run(() => this.GetDevelopersAsync()).Wait();
        }

        private async Task GetDevelopersAsync()
        {
            IEnumerable<Developer> devs = await _developerService.GetDevelopersAsync();

            _developers = new ObservableCollection<Developer>( devs );
        }

        private ObservableCollection<Developer> _developers;

        public ObservableCollection<Developer> Developers
        {
            get => _developers;
            set => SetProperty(ref _developers, value );
        }

        private Developer _selectedDeveloper;
        public Developer SelectedDeveloper
        {
            get => _selectedDeveloper;
            set
            {
                if (SetProperty(ref _selectedDeveloper, value))
                {
                    _ea.GetEvent<DeveloperInfoEvent>().Publish(_selectedDeveloper);
                }
            }
        }
    }
}
