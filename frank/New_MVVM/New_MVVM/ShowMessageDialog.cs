using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_MVVM
{
    public class ShowMessageDialog
    {
        private string _message;
        public string Message
        {
            get{ return _message; }
            set { _message = value; }
        }
    }
}

