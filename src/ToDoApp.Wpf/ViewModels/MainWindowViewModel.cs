using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Wpf.Commands;
using ToDoApp.Wpf.Models;

namespace ToDoApp.Wpf.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            Title = "My CSC200 Todo Task";
            TodoTaskItems = new ObservableCollection<TodoTaskViewModel>();
            AddTodoTaskCommand = new DelegateCommand(AddTodoTask, CanAddTodoTask);
        }

        public string Title { get; set; }

        public ICollection<TodoTaskViewModel> TodoTaskItems { get; set; }

        public ICommand AddTodoTaskCommand { get; }
        
        private void AddTodoTask(object value)
        {
            TodoTask model = new TodoTask();
            model.Description = value.ToString();
            TodoTaskViewModel viewModel = new TodoTaskViewModel(model);
            TodoTaskItems.Add(viewModel);
        }

        private bool CanAddTodoTask(object value)
        {
            return true;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
