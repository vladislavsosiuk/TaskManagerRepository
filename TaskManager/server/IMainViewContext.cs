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
        List<BusinessProject> GetAllProjects();        
        List<BussinessMyTask> GetAllTasks();
        List<BusinessProject> GetProjectsByUserID(int userID);
        List<BussinessMyTask> GetTasksByUserID(int userID);

    }
}
