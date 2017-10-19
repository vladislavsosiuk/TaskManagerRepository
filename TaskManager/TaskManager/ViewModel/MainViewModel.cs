using DataLayerFromDB;
using server;
using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainViewModel(IMainViewContext context)
        {
            Context = context;
            CurrentUser = Users[0];
        }
        #region Fields
        //List<BussinessMyTask> tasks;
        //List<BusinessProject> projects;
        //List<BusinessUser> users;
        BussinessMyTask currentTaskDone;
        BussinessMyTask currentTaskInWork;
        BusinessProject currentProject;
        BusinessUser currentUser;
        #endregion
        #region Properties
        public IMainViewContext Context { get; set; }
        public ObservableCollection<BussinessMyTask> TasksIsDone
        {
            get
            {
                //return tasks;
                return new ObservableCollection<BussinessMyTask>(Context.GetTasksByUserID(CurrentUser.UserID).Where(i => i.IsDone));
            }
            set
            {
                //tasks = value;
                OnPropertyChanged("tasks");
            }
        }
        public ObservableCollection<BussinessMyTask> TasksInWork
        {
            get
            {
                //return tasks;
                return new ObservableCollection<BussinessMyTask>(Context.GetTasksByUserID(CurrentUser.UserID).Where(i => !i.IsDone));
            }
            set
            {
                //tasks = value;
                OnPropertyChanged("tasks");
            }
        }
        public ObservableCollection<BusinessProject> Projects
        {
            get
            {
                //return projects;
                return new ObservableCollection<BusinessProject>(Context.GetProjectsByUserID(CurrentUser.UserID));
            }
            set
            {
                //projects = value;
                OnPropertyChanged("Projects");
            }
        }
        public ObservableCollection<BusinessUser> Users
        {
            get
            {
                //return users;
                return new ObservableCollection<BusinessUser>(Context.GetAllUsers());
            }
            set
            {
                //users = value;
                OnPropertyChanged("Users");
            }
        }
        public BussinessMyTask CurrentTaskInWork
        {
            get
            {
                return currentTaskInWork;
            }
            set
            {
                currentTaskInWork = value;
                OnPropertyChanged("CurrentTaskInWork");
            }
        }
        public string CurrentTaskInWorkTimeLeft
        {
            get
            {
                string res = (CurrentTaskInWork.TimeStop - CurrentTaskInWork.TimeStart).TotalHours.ToString();
                res += " часов до сдачи";
                return res;
            }
        }
        public BussinessMyTask CurrentTaskDone
        {
            get
            {
                return currentTaskDone;
            }
            set
            {
                currentTaskDone = value;
                OnPropertyChanged("CurrentTaskDone");
            }
        }
        public BusinessProject CurrentProject
        {
            get
            {
                return currentProject;
            }
            set
            {
                currentProject = value;
                OnPropertyChanged("CurrentProject");
            }
        }
        public BusinessUser CurrentUser
        {
            get
            {
                if (!string.IsNullOrEmpty(currentUser.Name))
                    return currentUser;
                else
                    return Users[0];
            }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        public int TasksCount
        {
            get
            {
                return DoneTasksCount+NotDoneTasksCount;
            }
        }
        public int DoneTasksCount
        {
            get
            {
                return TasksIsDone.Count();
            }
        }
        public int NotDoneTasksCount
        {
            get
            {
                return TasksInWork.Count();
            }
        }
        #endregion
        #region Commands
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
