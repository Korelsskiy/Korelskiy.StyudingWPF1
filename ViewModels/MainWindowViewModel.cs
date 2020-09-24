﻿using Korelskiy.StyudingWPF1.Infrastructure.Commands;
using Korelskiy.StyudingWPF1.ViewModels.Base;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

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

        private string _Status = "Готов!";

        public string Status { get => _Status; set => Set(ref _Status, value); }

        #endregion

        #region Команды

        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object parametr)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true; 
        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LyambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

        }
    }
}