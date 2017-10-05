using DataLair;
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
        public static General GeneralService { get; set; } = new General();
        public static BusinessUser CurrentUser { get; set; }
    }
}
