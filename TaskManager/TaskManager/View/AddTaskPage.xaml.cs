using MahApps.Metro.Controls;
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
using TaskManager.ViewModel;

namespace TaskManager.View
{
    /// <summary>
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTaskPage : MetroWindow
    {
        public MainView MainView { get; set; }
        public static AddTaskPage Current { get; set; }
        public AddTaskPage(MainView mainView)
        {
            //InitializeComponent();
            AddTaskPage.Current = this;

            DataContext = new AddTaskViewModel(mainView);
            MainView = mainView;

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            MainView.Show();
        }
    }
}
