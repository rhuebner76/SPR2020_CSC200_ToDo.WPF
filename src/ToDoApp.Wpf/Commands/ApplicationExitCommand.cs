using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ToDoApp.Wpf.Commands
{
    class ApplicationExitCommand : DelegateCommand
    {
        public ApplicationExitCommand() : 
            base(_ => Application.Current.MainWindow.Close(), _ => true)
        {

        }
    }
}
