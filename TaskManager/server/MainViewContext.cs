using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.BusinessLayer;
using DataLair;

namespace server
{
    public class MainViewContext : IMainViewContext
    {

        public ModelContext Context
        {
            get;set;
        }
        public MainViewContext(ModelContext context)
        {
            Context = context;
        }
        #region methods
        public List<BusinessProject> GetAllProjects()
        {

            var allProjects = Context.Projects.Select(p => new BusinessProject
            {
                ID = p.ID,
                Name = p.Name,
                OwnerUser = new BusinessUser
                {
                    Email = p.OwnerUser.Email,
                    Name = p.OwnerUser.Name,
                    UserID = p.OwnerUser.UserID,
                },
                Tasks = p.Tasks.Select(t => new BussinessMyTask
                {
                    CurrentPriority = t.CurrentPriority,
                    Description = t.Description,
                    ID = t.ID,
                    IsDone = t.IsDone,
                    Name = t.Name,
                    Prognosis = t.Prognosis,
                    ResponsibleUser = new BusinessUser
                    {
                        Email = t.ResponsibleUser.Email,
                        Name = t.ResponsibleUser.Name,
                        UserID = t.ResponsibleUser.UserID,
                    },
                    TimeStart = t.TimeStart,
                    TimeStop = t.TimeStop,
                }).ToList(),
            });
            return allProjects.ToList();
        }

        public List<BussinessMyTask> GetAllTasks()
        {
            var allTasks = Context.MyTasks.Select(t => new BussinessMyTask
            {
                CurrentPriority = t.CurrentPriority,
                Description = t.Description,
                ID = t.ID,
                IsDone = t.IsDone,
                Name = t.Name,
                Prognosis = t.Prognosis,
                ResponsibleUser = new BusinessUser
                {
                    Email = t.ResponsibleUser.Email,
                    Name = t.ResponsibleUser.Name,
                    UserID = t.ResponsibleUser.UserID,
                },
                TimeStart = t.TimeStart,
                TimeStop = t.TimeStop,
            }).ToList();
            return allTasks.ToList();
        }
        #endregion
        public List<BusinessUser> GetAllUsers()
        {
            var allUsers = Context.Users.Select(u => new BusinessUser
            {
                UserID=u.UserID,
                Name=u.Name,
                Email=u.Email,
                Password=u.Password,

            }).ToList();
            return allUsers.ToList();
        }

        public List<BusinessProject> GetProjectsByUserID(int userID)
        {
            var ProjectsById = Context.Projects.Where(p => p.OwnerUserID == userID).Select(p => new BusinessProject
            {
                ID = p.ID,
                Name = p.Name,
                OwnerUser = new BusinessUser
                {
                    Email = p.OwnerUser.Email,
                    Name = p.OwnerUser.Name,
                    UserID = p.OwnerUser.UserID,
                },
                Tasks = p.Tasks.Select(t => new BussinessMyTask
                {
                    CurrentPriority = t.CurrentPriority,
                    Description = t.Description,
                    ID = t.ID,
                    IsDone = t.IsDone,
                    Name = t.Name,
                    Prognosis = t.Prognosis,
                    ResponsibleUser = new BusinessUser
                    {
                        Email = t.ResponsibleUser.Email,
                        Name = t.ResponsibleUser.Name,
                        UserID = t.ResponsibleUser.UserID,
                    },
                    TimeStart = t.TimeStart,
                    TimeStop = t.TimeStop,
                }).ToList(),
            });
            return ProjectsById.ToList();
        }

        public List<BussinessMyTask> GetTasksByUserID(int userID)
        {     
            var TasksById = Context.MyTasks.Where(t=>t.UsersThatWorksOnThatTask.Any(u=>u.UserID==userID)).Select(t => new BussinessMyTask
            {
                CurrentPriority = t.CurrentPriority,
                Description = t.Description,
                ID = t.ID,
                IsDone = t.IsDone,
                Name = t.Name,
                Prognosis = t.Prognosis,
                ResponsibleUser = new BusinessUser
                {
                    Email = t.ResponsibleUser.Email,
                    Name = t.ResponsibleUser.Name,
                    UserID = t.ResponsibleUser.UserID,
                },
                TimeStart = t.TimeStart,
                TimeStop = t.TimeStop,
            }).ToList();
            return TasksById.ToList();
        }
    }
}