﻿using Korelskiy.StyudingWPF1.Infrastructure.Commands;
using Korelskiy.StyudingWPF1.Models;
using Korelskiy.StyudingWPF1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Korelskiy.StyudingWPF1.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        public ObservableCollection<Group> Groups { get; }
        public object[] CompositeCollection { get; }

        private object _selectedCompositeValue;
        public object SelectedCompositeValue
        {
            get => _selectedCompositeValue;
            set => Set(ref _selectedCompositeValue, value);
        }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set => Set(ref _selectedGroup, value);
        }
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

        public ICommand CreateNewGroupCommand { get; }

        private bool CanCreateGroupCommandExecute(object p) => true;
        private void OnCreateGroupCommandExecuted(object p)
        {
            var group_maxIndex = Groups.Count + 1;
            var new_group = new Group()
            {
                Name = $"Группа {group_maxIndex}",
                Students = new ObservableCollection<Student>()
            };

            Groups.Add(new_group);
        }


        public ICommand DeleteGroupCommand { get; }
        private bool CanDeleteGroupCommandExecute(object p) => p is Group group && Groups.Contains(group);
        private void OnDeleteGroupCommandExecuted(object p)
        {
            if (!(p is Group group)) return;
            var group_index = Groups.IndexOf(group);

            Groups.Remove(group);

            if (group_index < Groups.Count)
                SelectedGroup = Groups[group_index];
        }




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
            CreateNewGroupCommand = new LyambdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
            DeleteGroupCommand = new LyambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);

            #endregion

            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic =$"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });


            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(groups);

            var data_list = new List<object>();

            data_list.Add("Кирилл Владимирович");
            data_list.Add(15);
            data_list.Add(Groups[1]);
            data_list.Add(Groups[1].Students[1]);

            CompositeCollection = data_list.ToArray();
          
        }
    }
}
