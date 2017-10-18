using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.View;

namespace TaskManager.ViewModel
{
    class AddTaskViewModel
    {
        #region properties
        public MainView CurrentPage
        {
            get; set;
        }
        #endregion

        public AddTaskViewModel(MainView view)
        {
            CurrentPage = view;
        }
    }
}
