using System;
using System.Windows.Input;

namespace Korelskiy.StyudingWPF1.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged // изменить возможность выполенения
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter); // Проверяет, можно ли выполнить комманду

        public abstract void Execute(object parameter); // то что должно быть выполнено командой, ее основная логика
        
    }
}
