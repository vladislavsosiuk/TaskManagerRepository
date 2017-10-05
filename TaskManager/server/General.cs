using DataLair;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using server.BusinessLayer;

namespace server
{
    public class General : IGeneral
    {
        public ModelContext context;


        public BusinessUser Login(string email, string password)
        {

            var users = context.Users.Where(u => u.Email == email && u.Password == password).ToList();

            if (users != null && users.Count > 0 && CheckPass(password) && CheckEmailAddress(email))
            {
                var user = users.FirstOrDefault();
                return new BusinessUser { Name = user.Name };
            }
            return new BusinessUser { Result = new Result ( -1, "user not found!" )};

        }

        public BusinessUser SignUp(string email, string password, string name)
        {
            var user = new User() { Name = name, Email = email, Password = password };
            if (user.Name != null && user.Email != null && user.Password != null&& CheckPass(password)&& CheckEmailAddress(email)&& CheckEmailAddress(name))
            {
                context.Users.Add(user);
                context.SaveChanges();
                return new BusinessUser { Name = user.Name, Password = user.Password, Email = user.Email };
            }
            return new BusinessUser { Result = new Result(-1, "Registration is not succefull, something wrong with data") };


        }
        public Result ForgotPassword(string email)
        {

            var users = context.Users.Where(u => u.Email == email).ToList();
            
            if (users!=null && users.Count == 1&&CheckEmailAddress(email))
            {
               string pass= users.FirstOrDefault().Password;
                  return new Result(1, pass);
            }
            return new Result(-1, "User not found");
        }
        public List<MyTask> ActualTasks(int userID)
        {
            var users = context.Users.Where(u => u.UserID == userID).ToList();
            
            if(users!=null&& users.Count == 1)
            {
                var tasks = users.FirstOrDefault().Tasks;
                return new List<MyTask>();
            }
            return  new List<MyTask>();

        }
        public bool CheckPass(string pass)
        {
          int pass_lenght = pass.Length;
           if (pass_lenght == 8 || pass_lenght > 8)
                if (pass.Contains("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{8,15})$"))
                    return true;
            return false;
       }
      
        public static bool CheckEmailAddress(string email)
        {
            try
            {
                Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                return rx.IsMatch(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool CheckName(string name)
        {
            int name_lenght = name.Length;
            if (name_lenght == 2 || name_lenght > 2)
                if (name.Contains("(?!^[a-zA-Z]*$)^(.{2,15})$"))
                    return true;
            return false;
            
        }

        public Result RemindPassword(string email)
        {
            throw new NotImplementedException();
        }

        //Result IGeneral.ActualTasks(int userID)
        //{
        //    throw new NotImplementedException();
        //}

        public General()
        {
            context = new ModelContext();
        }
    }
}