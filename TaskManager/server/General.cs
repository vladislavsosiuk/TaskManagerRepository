using DataLair.DataModel;
using server.BusinessLayer;
using System;
using System.Linq;

namespace server
{
    public class General : IGeneral
    {
        public ModelContext context;
       

        public BusinessUser Login(string email, string password)
        {
            throw new NotImplementedException();

            //var users = context.Users.Where(u => u.Email && u.Password).ToList();
            //if (users!=null&&users.Count>0)
            //{
            //    var user = users.FirstOrDefault();
            //    return new BusinessUser { Name = user.Name };
            //}
            //return new BusinessUser { Result = new Result { Code = -1, Message = "user not found" } };
            
        }

        public BusinessUser SignUp(string email, string password, string name)
        {
            throw new NotImplementedException();
            //var user = new User() { Name = name, email = email, Password = password };
            //context.Users.Add(user);
            //context.SaveChanges();

        
        }
        public Result RemindPassword(string userName)
        {
            throw new NotImplementedException();
        }
        

        public General()
        {
            context = new ModelContext();
        }
    }
}