using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Helpers;
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
        Command addProjectCommand;
        Command addTaskCommand;
        #endregion
        #region Properties
        public MainView CurrentView{get;set;}
        public ICommand AddProjectCommand
        {
            get
            {
                if (addProjectCommand == null)
                    addProjectCommand = new Command(AddProject);
                return addProjectCommand;
            }
        }
        public ICommand AddTaskCommand
        {
            get
            {
                if (addTaskCommand == null)
                    addTaskCommand = new Command(AddTask);
                return addTaskCommand;
            }
        }
        #endregion
        #region Methods
        public void AddTask(object parameter)
        {
            
        }
        public void AddProject(object parameter)
        {

        }
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
