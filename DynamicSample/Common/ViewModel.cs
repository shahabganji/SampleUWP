using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common.Annotations;

namespace Common
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public abstract string Name { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
