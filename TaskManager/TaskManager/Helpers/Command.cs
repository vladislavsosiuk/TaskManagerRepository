using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Helpers
{
    class Command:ICommand
    {
        Action<object> action;
        Predicate<object> predicate;
        public Command(Action<object> action, Predicate<object> predicate=null)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (predicate == null)
                return true;
            return predicate(parameter);
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }

    }
}
