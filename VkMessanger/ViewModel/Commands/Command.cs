using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VkGUI
{
    class Command: ICommand
    {
        #region .ctor

        public Command(Action<object> action)
        {
            ExecuteDelegate = action;
        }
        #endregion

        #region Actions Properties
        public Predicate<object>  CanExecuteHandle { get; set; }
        public Action<object> ExecuteDelegate { get; set; } 
        #endregion


        #region ICommand Interface Members
        public bool CanExecute(object parameter)
        {
            if (CanExecuteHandle != null){
                return CanExecuteHandle(parameter);
            }

            return true;
        }

        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null){
                ExecuteDelegate(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
    }
}
