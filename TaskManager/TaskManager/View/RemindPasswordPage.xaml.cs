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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.ViewModel;

namespace TaskManager.View
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>

    public partial class RemindPasswordPage : MetroWindow
    {
        public LoginView LoginView { get; set; }
        public RemindPasswordPage(LoginView loginView)
        {
            InitializeComponent();

            DataContext = new RemindPasswordViewModel(this);

            LoginView = loginView;
            

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            LoginView.Show();
        }

    }
}
