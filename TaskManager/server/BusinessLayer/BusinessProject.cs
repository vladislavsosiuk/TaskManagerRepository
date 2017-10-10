using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.BusinessLayer
{
    public class BusinessProject
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //Ведущий проекта
        public  BusinessUser OwnerUser { get; set; }

        //Список задач проекта
        public List<BussinessMyTask> Tasks { get; set; }

        public BusinessProject()
        {
            Tasks = new List<BussinessMyTask>();
        }
    }
}