using Korelskiy.StyudingWPF1.ViewModels.Base;
using System.Runtime.CompilerServices;

namespace Korelskiy.StyudingWPF1.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        #region Заголовок окна
        private string _Title = "Истребители на вооружении стран мира";

        ///<summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();

            //    Set(ref _Title, value);
            //}

            set => Set(ref _Title, value);
        }

        #endregion
    }
}
