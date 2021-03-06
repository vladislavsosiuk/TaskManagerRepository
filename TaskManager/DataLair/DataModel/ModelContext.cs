﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLair
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("DbTaskManager")
        {
            Database.SetInitializer<ModelContext>(new InitDataBase());
            Database.Log = x => Console.WriteLine(x);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MyTask> MyTasks { get; set; }
    }
}
