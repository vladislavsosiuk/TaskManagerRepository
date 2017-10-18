using DataLayerFromDB;
using server;
using server.BusinessLayer;
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
        public MainViewModel(IMainViewContext context)
        {
            Context = context;
        }
        #region Fields
        //List<BussinessMyTask> tasks;
        //List<BusinessProject> projects;
        //List<BusinessUser> users;
        BussinessMyTask currentTask;
        BusinessProject currentProject;
        BusinessUser currentUser;
        #endregion
        #region Properties
        public IMainViewContext Context { get; set; }
        public List<BussinessMyTask> Tasks
        {
            get
            {
                //return tasks;
                if (string.IsNullOrEmpty(CurrentUser.Name))
                    return Context.GetAllTasks();
                else
                    return Context.GetTasksByUserID(CurrentUser.UserID);
            }
            set
            {
                //tasks = value;
                OnPropertyChanged("tasks");
            }
        }
        public List<BusinessProject> Projects
        {
            get
            {
                //return projects;
                if (string.IsNullOrEmpty(CurrentUser.Name))
                    return Context.GetAllProjects();
                else
                    return Context.GetProjectsByUserID(CurrentUser.UserID);
            }
            set
            {
                //projects = value;
                OnPropertyChanged("Projects");
            }
        }
        public List<BusinessUser> Users
        {
            get
            {
                //return users;
                return Context.GetAllUsers();
            }
            set
            {
                //users = value;
                OnPropertyChanged("Users");
            }
        }
        public BussinessMyTask CurrentTask
        {
            get
            {
                return currentTask;
            }
            set
            {
                currentTask = value;
                OnPropertyChanged("CurrentTask");
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
                return currentUser;
            }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        public int TaskCount
        {
            get
            {
                return Tasks.Count;
            }
        }
        public int DoneTasksCount
        {
            get
            {
                return Tasks.Select(t => t.IsDone).Count();
            }
        }
        public int NotDoneTasksCount
        {
            get
            {
                return Tasks.Select(t => !t.IsDone).Count();
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
