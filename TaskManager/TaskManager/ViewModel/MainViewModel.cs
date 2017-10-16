using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.View;

namespace TaskManager
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(MainView view)
        {
            CurrentView = view;
        }
        #region Fields
        #endregion
        #region Properties
        public MainView CurrentView{get;set;}

        #endregion
        #region Commands
        #endregion
        #region Methods
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
