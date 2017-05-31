using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetEventSample
{
    class MyPublisher
    {
        // public event Action<string> MyEvent;
        private Action<string> _myEvent;
        public event Action<string> MyEvent
        {
            add => _myEvent += value;
            remove => _myEvent -= value;
        }

        private void RaiseMyEvent(string message)
        {
            // _myEvent?.Invoke(message);
            if (_myEvent != null)
            {
                foreach (Action<string> myEvent in _myEvent.GetInvocationList())
                {
                    try
                    {
                        myEvent.Invoke(message);
                    }
                    catch
                    {
                        // unregister - use for()
                    }

                }
            }
        }


        public void Publish()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
