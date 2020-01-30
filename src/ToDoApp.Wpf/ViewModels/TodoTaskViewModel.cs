using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Wpf.Models;

namespace ToDoApp.Wpf.ViewModels
{
    class TodoTaskViewModel
    {
        private TodoTask TodoTask { get; }

        public TodoTaskViewModel(TodoTask todoTask)
        {
            this.TodoTask = todoTask;
        }

        public string Description
        {
            get { return TodoTask.Description; }
            set
            {
                TodoTask.Description = value;
                // todo: NotifyPropertyChanged(nameof(Description));
            }
        }
    }
}
