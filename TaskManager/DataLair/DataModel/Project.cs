using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class Project
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        //Ведущий проекта
        public int? OwnerUserID { get; set; }
        [ForeignKey(nameof(OwnerUserID))]
        public virtual User OwnerUser { get; set; }

        //Список задач проекта
        [InverseProperty(nameof(MyTask.Project))]
        public virtual List<MyTask> Tasks { get; set; }

        public Project()
        {
            Tasks = new List<MyTask>();
        }
    }
}
