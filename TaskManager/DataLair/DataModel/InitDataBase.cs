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
            User u1 = new User() { Name = "Vlad", Email = "@gmail.com", Password = "1234" };
            User u2 = new User() { Name = "Valdemar", Email = "@gmail.com", Password = "2341" };
            User u3 = new User() { Name = "Alina", Email = "dii.angelina13@gmail.com", Password = "3412" };
            User u4 = new User() { Name = "Alex", Email = "pyharef@gmail.com", Password = "4123" };

            Project proj = new Project() { Name = "TaskManagerProject", OwnerUser = u1 };

            MyTask t1 = new MyTask()
            {
                Name = "DBCreation",
                Description = "Создание модели базы данных",
                Project = proj,
                //ProjectID = proj.ID,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u4,
                //ResponsibleUserID = u4.UserID,
                UsersThatWorksOnThatTask = new List<User>() { u1, u3},
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0)
            };
            MyTask t2 = new MyTask()
            {
                Name = "ServerCreation",
                Description = "Написание серверной части",
                Project = proj,
                //ProjectID = proj.ID,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u2,
                //ResponsibleUserID = u2.UserID,
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
                //ProjectID = proj.ID,
                CurrentPriority = Priority.Normal,
                ResponsibleUser = u3,
                //ResponsibleUserID = u3.UserID,
                UsersThatWorksOnThatTask = new List<User>() { u1, u2 },
                TimeStart = new DateTime(2017, 10, 3),
                TimeStop = new DateTime(2017, 10, 22),
                Prognosis = new TimeSpan(2, 0, 0),
               
            };

            //u4.TasksToDo.Add(t1);
            //u2.TasksToDo.Add(t2);
            //u3.TasksToDo.Add(t3);

            context.Users.AddRange(new User[] { u1, u2, u3, u4 });
            context.MyTasks.AddRange(new MyTask[] { t1, t2, t3 });
            //proj.Tasks.AddRange(new MyTask[] { t1, t2, t3 });
            context.Projects.Add(proj);

            base.Seed(context);
        }
    }
}
