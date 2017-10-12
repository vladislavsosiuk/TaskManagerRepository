using DataLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using server.BusinessLayer;
using CheckData;

namespace server
{
    public class General : IGeneral
    {
        public ModelContext context;


        public BusinessUser Login(string email, string password)
        {
            var users = context.Users.Where(u => u.Email == email && u.Password == password).ToList();
            if (users != null && users.Count > 0)
            {
                var user = users.FirstOrDefault();
                var userToReturn = new BusinessUser { Name = user.Name, Password = user.Password, Email = user.Email, UserID=user.UserID};
                 var userTasks = context.MyTasks.Where(t => t.Observers.Contains(user)).Select(tt=>new BussinessMyTask
                 {
                     ID =tt.ID,
                     CurrentPriority =tt.CurrentPriority,
                     Description = tt.Description,
                     Name = tt.Name,
                     Prognosis = tt.Prognosis,
                     TimeStart = tt.TimeStart,
                     TimeStop = tt.TimeStop,                     
                 }).ToList();
                userToReturn.Tasks = userTasks;
                return userToReturn;

            }
            return new BusinessUser { Result = new Result(-1, "User not found") };
        }

        public BusinessUser SignUp(string email, string password, string name)
        {
            if (Checking.CheckPass(password))
                return new BusinessUser { Result = new Result(-1, "Password does not match the requirements!") };
            if (Checking.CheckPass(email))
                return new BusinessUser { Result = new Result(-2, "Email does not match the requirements!") };
            if (Checking.CheckName(name))
                return new BusinessUser { Result = new Result(-3, "Name does not match the requirements!") };
            var user = new User() { Name = name, Email = email, Password = password };
            context.Users.Add(user);
            context.SaveChanges();

            var userFromDb = context.Users.Where(u => u.Email == email && u.Password == u.Password).Select(ur => new BusinessUser
            {
                Email = ur.Email,
                Name = ur.Name,
                UserID = ur.UserID,
                Tasks = new List<BussinessMyTask>(),
            }).FirstOrDefault();
            return userFromDb;
        }
    
        public List<BussinessMyTask> ActualTasks(int userID)
        {

            var user = context.Users.Where(u => u.UserID == userID).FirstOrDefault();
            
            if(user!=null)
            {
               var tasks= user.Tasks.Select(t => new BussinessMyTask
                {
                    CurrentPriority = t.CurrentPriority,
                    Description = t.Description,
                    ID = t.ID,
                    Name = t.Name,
                    Prognosis = t.Prognosis,
                    TimeStart = t.TimeStart,
                    TimeStop = t.TimeStop,
                    Project = context.Projects.Where(p=>p.ID==t.ProjectID).Select(pp=>new BusinessProject
                    {
                        ID = pp.ID,
                        Name=pp.Name,
                        OwnerUser = context.Users.Where(u=>u.UserID== pp.OwnerUser.UserID).Select(uu=>new BusinessUser
                        {
                            Email=uu.Email,
                            Name=uu.Name,
                            UserID=uu.UserID,
                        }).First(),                        
                    }).FirstOrDefault(),
                    ResponsibleUser = context.Users.Where(u=>u.UserID==t.ResponsibleUserID).Select(su=>new BusinessUser
                    {
                        Email=su.Email,
                        Name = su.Name,
                        UserID = su.UserID,
                    }).FirstOrDefault(),
                }).ToList();   
                return tasks;
            }
            return null;

        }
      
        public Result RemindPassword(string email)
        {
            if(Checking.CheckEmailAddress(email))
                return new Result(-1, "Email does not match the requirements!");
            var user = context.Users.Where(u => u.Email == email).FirstOrDefault();
            if(user!=null)
            {
                string pass = user.Password;
                return new Result(1, pass);
            }
            return new Result(-2, "User not found");
        }


        public General()
        {
            context = new ModelContext();
        }
    }
}