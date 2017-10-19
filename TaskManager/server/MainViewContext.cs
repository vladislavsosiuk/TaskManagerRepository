using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using server.BusinessLayer;

namespace server
{
    public class MainViewContext : IMainViewContext
    {
        public List<BusinessProject> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public List<BussinessMyTask> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public List<BusinessUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<BusinessProject> GetProjectsByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public List<BussinessMyTask> GetTasksByUserID(int userID)
        {
            throw new NotImplementedException();
        }
    }
}