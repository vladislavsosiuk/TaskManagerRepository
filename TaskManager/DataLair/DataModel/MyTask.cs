using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class MyTask
    {
        [Key]
        public int ID { get; set; }

        //Название задачи
        public string Name { get; set; }

        //Ссылка на проект
        public int? ProjectID { get; set; }
        [ForeignKey(nameof(ProjectID))]
        public virtual Project Project { get; set; }

        //Ответственный за выполнение задачи        
        public int? ResponsibleUserID { get; set; }
        [ForeignKey(nameof(ResponsibleUserID))]
        public virtual User ResponsibleUser { get; set; }

        


        //Участники-наблюдатели
        [InverseProperty(nameof(User.TasksToDo))]
        public List<User> UsersThatWorksOnThatTask { get; set; }        
        //public virtual List<User> Observers { get; set; }

        public Priority CurrentPriority { get; set; }

        //Дата установки задачи
        public DateTime TimeStart { get; set; }

        //Конечный срок сдачи
        public DateTime TimeStop { get; set; }

        //Ориентировочное время выполнения
        public TimeSpan Prognosis { get; set; }

        //Суть задачи
        public string Description { get; set; }

        public MyTask()
        {
            UsersThatWorksOnThatTask = new List<User>();
        }
    }

    //Варианты приоритета
    public enum Priority
    {
        Normal,
        Express,
        Critical
    }
}
