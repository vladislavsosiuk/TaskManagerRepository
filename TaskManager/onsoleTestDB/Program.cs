using DataLair;
using DataLayerFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelContext Context = new ModelContext();
           // DbEntities Context = new DbEntities();
            var users = Context.Users.ToList();
            foreach(var user in users)
            {
                Console.WriteLine($" {user.Name} {user.Email}");
            }
            Console.WriteLine();

            var tasks = Context.MyTasks.ToList();
            foreach (var item in tasks)
            {
                Console.WriteLine(item.Name);
            }

            //var projects = Context.Projects;
            //foreach (Project p in projects)
            //{
            //    Console.WriteLine($" {p.Name} {p.OwnerUser.Name}");

                //    var tasks = p.Tasks;
                //    foreach (MyTask t in tasks)
                //    {
                //        Console.WriteLine($" Project {t.Name},  Description: {t.Description}");
                //        Console.WriteLine($"{t.ResponsibleUser}");
                //        Console.WriteLine();
                //    }
                //}
                //Console.ReadLine();
            }
    }
}
