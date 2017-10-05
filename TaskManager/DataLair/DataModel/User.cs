
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }

        [Index(IsUnique = true)]
        public string Email { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public string Password { get; set; }
        public virtual List<MyTask> Tasks { get; set; }
    }
}
