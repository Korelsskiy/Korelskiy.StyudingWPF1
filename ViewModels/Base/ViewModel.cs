using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Korelskiy.StyudingWPF1.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged // Этот интерфейс отслеживает какоето свойство и меняет его значение в визуальном интерфейсе 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
