using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class Project
    {
        public int ID { get; set; }

        public string Name { get; set; }

        //Ведущий проекта
        [ForeignKey("OwnerUser")]
        public int OwnerUserID { get; set; }
        public virtual User OwnerUser { get; set; }

        //Список задач проекта
        public virtual List<MyTask> Tasks { get; set; }

        public Project()
        {
            Tasks = new List<MyTask>();
        }
    }
}
