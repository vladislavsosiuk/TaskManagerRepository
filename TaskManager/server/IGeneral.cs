using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    [ServiceContract]
    interface IGeneral
    {
        [OperationContract]
        Result Login(string email, string password);
        [OperationContract]
        Result SignUp(string email, string password, string name);
        [OperationContract]
        Result RemindPassword(string email);
        [OperationContract]
        Result ActualTasks(int userID);
    }
}
