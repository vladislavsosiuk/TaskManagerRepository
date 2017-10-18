using server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using server.BusinessLayer;

namespace DataLayerFromDB
{
    public class Model : IMainViewContext
    {
        DbEntities context = new DbEntities();
        public List<BusinessProject> GetAllProjects()
        {
            throw new NotImplementedException();
            //return context.Projects.Select(p =>
            //                                new BusinessProject
            //                                {
            //                                    ID = p.ID, Name = p.Name, OwnerUser = p.User, Tasks = p.MyTasks
            //                                }).ToList();
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
