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

namespace ViewModels
{
    public class DeveloperListViewModel : BindableBase
    {
        private IEventAggregator _ea;

        public DeveloperListViewModel( IDeveloperService developerService, IEventAggregator ea )
        {
            _developers = new ObservableCollection<Developer>(developerService.GetDevelopers());

            _ea = ea;
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
