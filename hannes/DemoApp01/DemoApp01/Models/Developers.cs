
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp01.Helpers;

namespace DemoApp01.Models
{
    public class Developer : BindableBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty( ref _name, value );
        }

        private string _email;

        public string EMail
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;

        public string Password
        { 
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private DateTime _birthDay;

        public DateTime BirthDay
        {
            get => _birthDay;
            set => SetProperty(ref _birthDay, value);
        }

        private bool _developsCSharp;
        public bool DevelopsCSharp
        {
            get => _developsCSharp;
            set => SetProperty(ref _developsCSharp, value);
        }
    }
}
