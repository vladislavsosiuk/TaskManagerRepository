using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server
{
    public class General : IGeneral
    {
        public ModelContext context;
       

        public Result Login(string email, string password)
        {

            var users = context.Users.Where(u => u.Email && u.Password).ToList();
            if (users!=null&&users.Count>0)
            {

                return new Result(1,"Login succesfull!");
            }
            return new Result(-1, "User not found!");
            
        }

        public Result SignUp(string email, string password, string name)
        {
            var user = new User() { Name = name, email = email, Password = password };
            context.Users.Add(user);
            context.SaveChanges();

        
        }
       public General()
        {
            context = new ModelContext();
        }
    }
}