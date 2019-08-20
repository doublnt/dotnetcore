using System;
using System.Windows.Input;

using WpfMvvm.ViewModel;

namespace WpfMvvm.Command
{
    public class PersonViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _whatToExecute;
        private Func<bool> _whenToExecute;


        public PersonViewModelCommand(Action what, Func<bool> when)
        {
            _whatToExecute = what;
            _whenToExecute = when;
        }

        public bool CanExecute(object parameter)
        {
            return _whenToExecute();
        }

        public void Execute(object parameter)
        {
            _whatToExecute();
        }
    }
}