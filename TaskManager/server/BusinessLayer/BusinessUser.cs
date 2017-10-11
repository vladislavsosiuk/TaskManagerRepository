using DataLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.BusinessLayer
{
    public class BusinessUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<BussinessMyTask> Tasks { get; set; }
        public Result Result { get; set; }
    }
}