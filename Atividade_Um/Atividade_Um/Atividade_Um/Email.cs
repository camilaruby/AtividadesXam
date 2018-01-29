using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Atividade_Um
{
    class Email : INotifyPropertyChanged
    {

        private string loginEmail;
        public string LoginEmail
        {
            get
            {
                return loginEmail;
            }
            set
            {
                loginEmail = value;
                EventPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


}
