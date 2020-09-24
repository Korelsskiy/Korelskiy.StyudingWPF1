using Korelskiy.StyudingWPF1.Infrastructure.Commands.Base;
using System.Windows;

namespace Korelskiy.StyudingWPF1.Infrastructure.Commands
{
    class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
