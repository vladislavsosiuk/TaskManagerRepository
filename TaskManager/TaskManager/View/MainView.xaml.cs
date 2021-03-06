﻿using MahApps.Metro.Controls;
using server;
using server.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskManager.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow
    {
        //public MainView(IMainViewContext context)
        //{
        //    InitializeComponent();     
        //    this.DataContext = new MainViewModel(context);
        //}
        public MainView()
        {
            IMainViewContext context = new BusinessINIT();
            InitializeComponent();
            this.DataContext = new MainViewModel(context);
        }
    }
}
