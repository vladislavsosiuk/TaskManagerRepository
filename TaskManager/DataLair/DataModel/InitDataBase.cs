using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    class InitDataBase : DropCreateDatabaseAlways<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            User u1 = new User() { Name = "Vlad", Email = "vlad@gmail.com", Password = "12asdfvdffbfr34" };
            User u2 = new User() { Name = "Valdemar", Email = "valdemar@gmail.com", Password = "acs34esdd" };
            User u3 = new User() { Name = "Alina", Email = "dii.angelina13@gmail.com", Password = "3qdce4134rfd2" };
            User u4 = new User() { Name = "Alex", Email = "pyharef@gmail.com", Password = "41oijhgfr23" };
            User u5 = new User() { Name = "Dima", Email = "dima@gmail.com", Password = "567wedfv89" };
            User u6 = new User() { Name = "Ola", Email = "ola@gmail.com", Password = "4987ygHG123" };
            User u7 = new User() { Name = "Mihael", Email = "mihael@gmail.com", Password = "412I&gyHGfgh3" };
            User u8 = new User() { Name = "Serg", Email = "serg@gmail.com", Password = "412IUY3ERFG3" };

            Project proj = new Project() { Name = "TaskManagerProject", OwnerUser = u1 };
            Project proj1 = new Project() { Name = "SuperGame", OwnerUser = u7 };

            MyTask t1 = new MyTask()
            {
                Name = "DBCreation",
                Description = "Создание модели базы данных",
                Project = proj,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u4,
                UsersThatWorksOnThatTask = new List<User>() { u1, u3 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0)
            };
            MyTask t2 = new MyTask()
            {
                Name = "ServerCreation",
                Description = "Написание серверной части",
                Project = proj,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u2,
                UsersThatWorksOnThatTask = new List<User>() { u1, u4 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0)
            };
            MyTask t3 = new MyTask()
            {
                Name = "ViewCreation",
                Description = "Окно входа и регистраци",
                Project = proj,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u3,
                UsersThatWorksOnThatTask = new List<User>() { u1, u2 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),

            };
            MyTask t4 = new MyTask()
            {
                Name = "ViewCreation",
                Description = "Окно входа и регистраци",
                Project = proj1,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u5,
                UsersThatWorksOnThatTask = new List<User>() { u8, u6 },
                TimeStart = new DateTime(2017, 10, 4),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),

            };
            MyTask t5 = new MyTask()
            {
                Name = "DBGameCreation",
                Description = "Создание модели базы данных",
                Project = proj1,
                CurrentPriority = Priority.Express,
                ResponsibleUser = u8,
                UsersThatWorksOnThatTask = new List<User>() { u6, u5 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0)
            };
            MyTask t6 = new MyTask()
            {
                Name = "ServerCreation",
                Description = "Написание серверной части",
                Project = proj1,
                CurrentPriority = Priority.Critical,
                ResponsibleUser = u2,
                UsersThatWorksOnThatTask = new List<User>() { u7, u6 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0)
            };
            MyTask t7 = new MyTask()
            {
                Name = "MainViewCreation",
                Description = "Написание главного вида игры",
                Project = proj1,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u6,
                UsersThatWorksOnThatTask = new List<User>() { u7, u5 },
                TimeStart = new DateTime(2017, 10, 7),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0)
            };

            context.Users.AddRange(new User[] { u1, u2, u3, u4, u5, u6, u7, u8 });
            context.MyTasks.AddRange(new MyTask[] { t1, t2, t3, t4, t5, t6, t7 });
            context.Projects.AddRange(new Project[] { proj, proj1 });

            base.Seed(context);
        }
    }
}
