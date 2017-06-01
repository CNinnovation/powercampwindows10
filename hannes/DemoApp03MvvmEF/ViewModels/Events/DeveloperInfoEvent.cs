using Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Events
{
    public class DeveloperInfoEvent : PubSubEvent<Developer>
    {
        public Developer Developer
        {
            get;
            set;
        }
    }
}
