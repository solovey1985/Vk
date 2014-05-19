using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using ViewModels.Annotations;
using Vk.Interfaces.ViewModels;

namespace Vk.DTO.ViewModels
{
    public class ViewModel: INotifyPropertyChanged, IViewModel
    {
        public string ViewName { get; set; }

        internal BaseCommand command;

        #region InotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
