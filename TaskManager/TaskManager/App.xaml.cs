﻿using DataLair;
using server;
using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static GeneralService.GeneralClient GeneralService { get; set; }
        public static BusinessUser CurrentUser { get; set; }
       
        public App()
        {
            App.GeneralService = new GeneralService.GeneralClient();

            //ModelContext context = new ModelContext();
            //var users = context.Users;

            //foreach (var r in users)
            //{
            //    var user = r;
            //}
        }
    }
}
