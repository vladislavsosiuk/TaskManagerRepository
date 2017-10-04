using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class MyTask
    {
        public int ID { get; set; }

        //Название задачи
        public string Name { get; set; }

        //Ссылка на проект
        [ForeignKey("Project")]
        public int ProjectID { get; set; } 
        public virtual Project Project { get; set; }

        //Ответственный за выполнение задачи
        [ForeignKey("ResponsibleUser")]
        public int ResponsibleUserID { get; set; }
        public virtual User ResponsibleUser { get; set; }

        //Участники-наблюдатели
        public virtual List<User> Observers { get; set; }

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
            Observers = new List<User>();
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
