using server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(General));
            //NetTcpBinding binding = new NetTcpBinding();
            //sh.AddServiceEndpoint(typeof(IGeneral), binding);//, binding, new Uri("net.tcp://localhost:30000/General/ep1"));
            sh.Open();
            Console.WriteLine("started");
            Console.ReadKey();
            sh.Close();
        }
    }
}

