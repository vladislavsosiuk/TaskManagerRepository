using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Helpers;
using server;
using CheckData;
using System.Runtime.CompilerServices;
using System.Net;
using TaskManager.View;
using MahApps.Metro.Controls.Dialogs;

namespace TaskManager.ViewModel
{
    // await CurrentPage.ShowMessageAsync("Ошибка", resultUser.Result.ResultMessage);
    class SignUpViewModel : INotifyPropertyChanged
    {
        #region fields
        Command signUpCommandReg;
        bool isLoading;
        public event PropertyChangedEventHandler PropertyChanged;
        string email;
        string password;
        string name;

        #endregion
        #region properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
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
        public ICommand SignUpCommandReg
        {
            get
            {
                if (signUpCommandReg == null)
                    signUpCommandReg = new Command(SignUpReg, CanSignUp);
                return signUpCommandReg;
            }
        }
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
        
        #endregion
        #region methods
        public SignUpViewModel(LoginView view)
        {
            CurrentPage = view;
        }

        public async void SignUpReg(object parameter)
        {
            IsLoading = true;
            try
            {
                var result = await Task.Run(() => App.GeneralService.SignUp(Email, Password, Name));
                if(result.Result==null)
                {
                    App.CurrentUser = result;
                }
                else
                {
                    await SignUpPage.Current?.ShowMessageAsync("Ошибка", result.Result.ResultMessage);
                }

            }

            catch (WebException)
            {
                await SignUpPage.Current?.ShowMessageAsync("Ошибка", "Проверьте подключение к интернету");

            }
            finally
            {
                IsLoading = false;
            }
        }
        public bool CanSignUp(object parameter)
        {
            if (!Checking.CheckEmailAddress(Email))
            {
                return false;
            }
            else if (!Checking.CheckPass(Password))
            {
                return false;
            }
            else if (!Checking.CheckName(Name))
            {
                return false;
            }
            return true;

        }
        public void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion








    }
}
