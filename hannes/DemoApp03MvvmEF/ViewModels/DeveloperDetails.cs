using Microsoft.Extensions.DependencyInjection.Extensions;
using Models;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Events;

namespace ViewModels
{
    public class DeveloperDetailsViewModel : BindableBase
    {
        private IEventAggregator _ea;

        public DeveloperDetailsViewModel( IEventAggregator ea)
        {
            _ea = ea;

            _ea.GetEvent<DeveloperInfoEvent>().Subscribe( d =>
            {
                Developer = d;

            });
        }

        private Developer _developer;
        public Developer Developer
        {
            get => _developer;
            set => SetProperty(ref _developer, value);
        }
    }
}

