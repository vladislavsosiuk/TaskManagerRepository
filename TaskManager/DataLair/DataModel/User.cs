
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }

        //[Index(IsUnique = true)]
        //[MaxLength(255)]
        public string Email { get; set; }
        //public virtual IPEndPoint IPEndPoint { get; set; }
        public string Password { get; set; }

        [InverseProperty(nameof(MyTask.ResponsibleUser))]
        public virtual List<MyTask> RespponsibleTasks { get; set; }
        [InverseProperty(nameof(MyTask.UsersThatWorksOnThatTask))]
        public virtual List<MyTask> TasksToDo { get; set; }
        //[InverseProperty("OwnerUser")]
        [InverseProperty(nameof(Project.OwnerUser))]
        public virtual List<Project> Projects { get; set; }
        //public virtual List<MyTask> ActualTasks { get; set; }
        public User()
        {
            RespponsibleTasks = new List<MyTask>();
            Projects = new List<Project>();
            TasksToDo = new List<MyTask>();
        }

    }
}
