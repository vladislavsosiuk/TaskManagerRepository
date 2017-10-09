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
            if(CheckPass(password))
                return new BusinessUser { Result = new Result(-1, "Password does not match the requirements!") };
            if (CheckPass(email))
                return new BusinessUser { Result = new Result(-2, "Email does not match the requirements!") };
            var users = context.Users.Where(u => u.Email == email && u.Password == password).ToList();
            if (users != null && users.Count > 0)
            {
                var user = users.FirstOrDefault();
                return new BusinessUser { Name = user.Name, Password = user.Password, Email = user.Email, UserID=user.UserID, Tasks=user.Tasks};
            }
            return new BusinessUser { Result = new Result(-3, "Login is not succefull, something going wrong!") };
        }

        public BusinessUser SignUp(string email, string password, string name)
        {
            if (CheckPass(password))
                return new BusinessUser { Result = new Result(-1, "Password does not match the requirements!") };
            if (CheckPass(email))
                return new BusinessUser { Result = new Result(-2, "Email does not match the requirements!") };
            if (CheckName(name))
                return new BusinessUser { Result = new Result(-3, "Name does not match the requirements!") };
            var user = new User() { Name = name, Email = email, Password = password };
            if (user.Name != null && user.Email != null && user.Password != null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return new BusinessUser { Name = user.Name, Password = user.Password, Email = user.Email, UserID = user.UserID, Tasks = user.Tasks};
            }
            return new BusinessUser { Result = new Result(-4, "Registration is not succefull, something going wrong!") };


        }
    
        public List<MyTask> ActualTasks(int userID)
        {

            var users = context.Users.Where(u => u.UserID == userID).ToList();
            
            if(users!=null&& users.Count == 1)
            {
                var tasks = users.FirstOrDefault().Tasks;
                return tasks;
            }
            return null;

        }
        public bool CheckPass(string pass)
        {
            // от 6 до 15 символов
            try
            {
                Regex rx = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^(.{6,15})$");
                return rx.IsMatch(pass);
            }
            catch (FormatException)
            {
                return false;
            }
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
            //Цифры в имени должны отсуствоватть, от 2 до 15 символов
            try
            {
                Regex rx = new Regex(@"(?!^[a-zA-Z]*$)^(.{2,15})$");
                return rx.IsMatch(name);
            }
            catch (FormatException)
            {
                return false;
            }

        }

        public Result RemindPassword(string email)
        {
            if(CheckEmailAddress(email))
                return new Result(-1, "Email does not match the requirements!");
            var users = context.Users.Where(u => u.Email == email).ToList();
            if (users != null && users.Count == 1 )
            {
                string pass = users.FirstOrDefault().Password;
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