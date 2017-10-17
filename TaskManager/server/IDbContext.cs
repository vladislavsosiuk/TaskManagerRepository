using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public interface IDbContext
    {
        List<BusinessProject> GetProjects();
        List<BusinessUser> GetUsers();
        List<BussinessMyTask> GetTasks();
    }
}
