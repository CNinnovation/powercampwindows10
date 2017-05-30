using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TheBestMVVMFrameworkInTown
{
    public class DelegateCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;
        public DelegateCommand(Action execute)
            : this(execute, null)
        {

        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        //public bool DummyCanExecute(object parameter)
        //{
        //    if (_canExecute == null)
        //        return true;

        //    return _canExecute();
        //}


        public void Execute(object parameter) => _execute();
    }
}
