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
using TaskManager.View;

namespace TaskManager
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(IDbContext context)
        {
            Context = context;
            Projects = context.GetProjects();
            Users = context.GetUsers();
            Tasks = context.GetTasks();
        }
        #region Fields
        List<BussinessMyTask> tasks;
        List<BusinessProject> projects;
        List<BusinessUser> users;
        BussinessMyTask currentTask;
        BusinessProject currentProject;
        BusinessUser currentUser;
        #endregion
        #region Properties
        public IDbContext Context { get; set; }
        public List<BussinessMyTask> Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
                OnPropertyChanged("tasks");
            }
        }
        public List<BusinessProject> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
                OnPropertyChanged("Projects");
            }
        }
        public List<BusinessUser> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
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
