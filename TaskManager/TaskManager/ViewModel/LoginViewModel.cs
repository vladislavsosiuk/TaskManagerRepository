﻿using MahApps.Metro.Controls.Dialogs;
using server;
using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaskManager.Helpers;
using TaskManager.View;
using CheckData;

namespace TaskManager
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel(LoginView view)
        {
            CurrentPage = view;
        }
        #region fields
        Command loginCommand;
        Command forgotPasswordCommand;
        Command signUpCommand;
        bool isLoading;
        #endregion
        #region properties
        public LoginView CurrentPage
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
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                    loginCommand = new Command(Login, CanLogin);
                return loginCommand;
            }
        }
        public ICommand SignUpCommand
        {
            get
            {
                if (signUpCommand == null)
                    signUpCommand = new Command(SignUp);
                return signUpCommand;
            }
        }
        public ICommand ForgotPasswordCommand
        {
            get
            {
                if (forgotPasswordCommand == null)
                    forgotPasswordCommand = new Command(RemindPassword);
                return forgotPasswordCommand;
            }
        }

        #endregion
        #region methods
        public void SignUp(object parameter)
        {
            var signUpPage = new SignUpPage(CurrentPage);
            signUpPage.Show();
            CurrentPage.Hide();
        }
        public void RemindPassword(object parameter)
        {

            var remindPasswordPage = new RemindPasswordPage(CurrentPage);
            remindPasswordPage.Show();
            CurrentPage.Hide();
        }

     
        public bool CanLogin(object parameter)
        {
            var pBox = parameter as PasswordBox;
            if (pBox == null)
                return false;
            var pass = pBox.Password;
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(pass);

        }
        public async void Login(object parameter)
        {
            IsLoading = true;

            try
            {
               
                
                var resultUser = await Task<BusinessUser>.Run(() => App.GeneralService.Login(UserName, Password));
                
                if (resultUser.Result == null)
                {
                    App.CurrentUser = resultUser;

                }
                else
                {
                    await CurrentPage.ShowMessageAsync("Ошибка", resultUser.Result.ResultMessage);
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
        #endregion


        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                if (value != _isAuthenticated)
                    _isAuthenticated = value;
                OnPropertyChanged("IsAuthenticated");
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        

        public void OnPropertyChanged([CallerMemberName]string name="")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
