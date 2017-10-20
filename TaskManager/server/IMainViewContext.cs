using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public interface IMainViewContext
    {
        List<BusinessUser> GetAllUsers();
        List<BusinessProject> GetProjectsByUserID(int userID);
        List<BussinessMyTask> GetTasksByUserID(int userID);
        List<BusinessProject> GetAllProjects();
        List<BussinessMyTask> GetAllTasks();
    }
}
