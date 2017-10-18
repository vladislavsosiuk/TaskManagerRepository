using DataLair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.BusinessLayer
{
    public class BussinessMyTask
    {
        public int ID { get; set; }

        //Название задачи
        public string Name { get; set; }

        //Ссылка на проект
        public BusinessProject Project { get; set; }

        //Ответственный за выполнение задачи
        public virtual BusinessUser ResponsibleUser { get; set; }

        //Участники-наблюдатели
        public List<BusinessUser> Observers { get; set; }

        public Priority CurrentPriority { get; set; }

        //Дата установки задачи
        public DateTime TimeStart { get; set; }

        //Конечный срок сдачи
        public DateTime TimeStop { get; set; }

        //Ориентировочное время выполнения
        public TimeSpan Prognosis { get; set; }

        //Суть задачи
        public string Description { get; set; }

        public bool IsDone { get; set; }
        public Result Result { get; set; }
        public BussinessMyTask()
        {
            Observers = new List<BusinessUser>();
        }
    }
}
