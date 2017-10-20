using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Helpers;
using server;
using MahApps.Metro.Controls.Dialogs;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using TaskManager.View;

namespace TaskManager.ViewModel
{
    class RemindPasswordViewModel : INotifyPropertyChanged
    {
        string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public RemindPasswordViewModel(RemindPasswordPage view)
        {
            CurrentPage = view;
        }
        Command forgotPasswordCommand;
        bool isLoading;
        public RemindPasswordPage CurrentPage
        {
            get; set;
        }

        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }
        public ICommand RemindPasswordCommand
        {
            get
            {
                if (forgotPasswordCommand == null)
                    forgotPasswordCommand = new Command(RemindPassword, CanRemindPassword);
                return forgotPasswordCommand;
            }
        }    
        private void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool CanRemindPassword(object parameter)
        {
            return !string.IsNullOrEmpty(Email);
        }
        public async void RemindPassword(object parameter)
        {
            IsLoading = true;
            try
            {
                var result = await Task<Result>.Run(() => App.GeneralService.RemindPassword(Email));
                if (result.ResultCode > 0)
                {
                    await CurrentPage.ShowMessageAsync("Ваш пароль", result.ResultMessage);
                }
                else
                {
                    await CurrentPage.ShowMessageAsync("Ошибка", result.ResultMessage);
                }
            }
            catch (WebException)
            {
                await CurrentPage.ShowMessageAsync("Ошибка", "Проверьте подключение к интернету");
            }
            finally
            {
                IsLoading = false;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
