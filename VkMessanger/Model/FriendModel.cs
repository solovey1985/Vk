using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VkGUI.Annotations;

namespace VkGUI.Model
{
    public class FriendModel: INotifyPropertyChanged
    {
        private string name;
        private string surname;
        public String Name{get { return name; }
            set { if (name != value) name = value; OnPropertyChanged("Name"); } }

        public String Surname
        {
            get { return surname; }
            set { if (surname != value) surname = value; OnPropertyChanged("Surname"); }
        }
      

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
