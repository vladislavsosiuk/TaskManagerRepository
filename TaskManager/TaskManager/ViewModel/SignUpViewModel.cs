using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Helpers;
using server;

namespace TaskManager.ViewModel
{
    class SignUpViewModel : INotifyPropertyChanged
    {
        public SignUpViewModel(LoginView view)
        {
            CurrentPage = view;
        }
        Command signUpCommandReg;
        bool isLoading;
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
                    signUpCommandReg = new Command(SignUpReg);
                return signUpCommandReg;
            }
        }
        public void SignUpReg(object parameter)
        {
            
        }
        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
