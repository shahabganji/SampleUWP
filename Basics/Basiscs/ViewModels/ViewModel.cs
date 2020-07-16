using System.ComponentModel;
using System.Runtime.CompilerServices;
using App1.Annotations;

namespace App1.ViewModels
{
    public class ViewModel  :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}