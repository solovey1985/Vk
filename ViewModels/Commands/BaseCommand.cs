using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Vk.DTO.ViewModels
{
    public class BaseCommand: ICommand
    {
        public BaseCommand(Action<object> action)
        {
            ExecuteDelegate = action;
        }

        public Predicate<object>  CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }


        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null){
                ExecuteDelegate(parameter);
            }
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null){
                return CanExecuteDelegate(parameter);
            }
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
