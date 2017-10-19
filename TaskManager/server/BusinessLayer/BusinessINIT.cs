using DataLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.BusinessLayer
{
    public class BusinessINIT : IMainViewContext
    {
        public List<BusinessUser> Users { get; set; }
        public List<BusinessProject> Projects { get; set; }
        public List<BussinessMyTask> Tasks { get; set; }

        public BusinessINIT()
        {
            Users = new List<BusinessUser>();
            Projects = new List<BusinessProject>();
            Tasks = new List<BussinessMyTask>();

            BusinessUser u1 = new BusinessUser() { Name = "Vlad", Email = "vlad@gmail.com", Password = "12asdfvdffbfr34" };
            BusinessUser u2 = new BusinessUser() { Name = "Valdemar", Email = "valdemar@gmail.com", Password = "acs34esdd" };
            BusinessUser u3 = new BusinessUser() { Name = "Alina", Email = "dii.angelina13@gmail.com", Password = "3qdce4134rfd2" };
            BusinessUser u4 = new BusinessUser() { Name = "Alex", Email = "pyharef@gmail.com", Password = "41oijhgfr23" };
            BusinessUser u5 = new BusinessUser() { Name = "Dima", Email = "dima@gmail.com", Password = "567wedfv89" };
            BusinessUser u6 = new BusinessUser() { Name = "Ola", Email = "ola@gmail.com", Password = "4987ygHG123" };
            BusinessUser u7 = new BusinessUser() { Name = "Mihael", Email = "mihael@gmail.com", Password = "412I&gyHGfgh3" };
            BusinessUser u8 = new BusinessUser() { Name = "Serg", Email = "serg@gmail.com", Password = "412IUY3ERFG3" };

            BusinessProject proj = new BusinessProject() { Name = "TaskManagerProject", OwnerUser = u1 };
            BusinessProject proj1 = new BusinessProject() { Name = "SuperGame", OwnerUser = u7 };

            BussinessMyTask t1 = new BussinessMyTask()
            {
                Name = "DBCreation",
                Description = "Создание модели базы данных",
                Project = proj,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u4,
                Observers = new List<BusinessUser>() { u1, u3 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u1, u3 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone=true
            };
            BussinessMyTask t2 = new BussinessMyTask()
            {
                Name = "ServerCreation",
                Description = "Написание серверной части",
                Project = proj,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u2,
                Observers = new List<BusinessUser>() { u1, u4 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u1, u4 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone = false
            };
            BussinessMyTask t3 = new BussinessMyTask()
            {
                Name = "ViewCreation",
                Description = "Окно входа и регистраци",
                Project = proj,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u3,
                Observers = new List<BusinessUser>() { u1, u2 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u1, u2 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone = false
            };
            BussinessMyTask t4 = new BussinessMyTask()
            {
                Name = "ViewCreation",
                Description = "Окно входа и регистраци",
                Project = proj1,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u5,
                Observers = new List<BusinessUser>() { u8, u6 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u8, u6 },
                TimeStart = new DateTime(2017, 10, 4),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone = false

            };
            BussinessMyTask t5 = new BussinessMyTask()
            {
                Name = "DBGameCreation",
                Description = "Создание модели базы данных",
                Project = proj1,
                CurrentPriority = Priority.Express,
                ResponsibleUser = u8,
                Observers = new List<BusinessUser>() { u6, u5 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u6, u5 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone = false
            };
            BussinessMyTask t6 = new BussinessMyTask()
            {
                Name = "ServerCreation",
                Description = "Написание серверной части",
                Project = proj1,
                CurrentPriority = Priority.Critical,
                ResponsibleUser = u2,
                Observers = new List<BusinessUser>() { u7, u6 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u7, u6 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone = false
            };
            BussinessMyTask t7 = new BussinessMyTask()
            {
                Name = "MainViewCreation",
                Description = "Написание главного вида игры",
                Project = proj1,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u6,
                Observers = new List<BusinessUser>() { u7, u5 },
                //UsersThatWorksOnThatTask = new List<BusinessUser>() { u7, u5 },
                TimeStart = new DateTime(2017, 10, 7),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
                IsDone = false
            };

            Users.AddRange(new BusinessUser[] { u1, u2, u3, u4, u5, u6, u7, u8 });
            Tasks.AddRange(new BussinessMyTask[] { t1, t2, t3, t4, t5, t6, t7 });
            Projects.AddRange(new BusinessProject[] { proj, proj1 });
        }

        public List<BusinessUser> GetAllUsers()
        {
            return Users;
        }

        public List<BusinessProject> GetProjectsByUserID(int userID)
        {
            return Projects.Where(i => i.ID == userID).ToList();
        }

        public List<BussinessMyTask> GetTasksByUserID(int userID)
        {
            return Tasks.Where(i => i.ID == userID).ToList();
        }
    }
}