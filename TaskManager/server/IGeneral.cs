using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using server.BusinessLayer;
namespace server
{
    [ServiceContract]
    interface IGeneral
    {
        [OperationContract]
        BusinessUser Login(string email, string password);
        [OperationContract]
        BusinessUser SignUp(string email, string password, string name);
        [OperationContract]
        BusinessUser ForgotPassword(string email);
        [OperationContract]
        BusinessUser ActualTasks(int userID);
    }
}
