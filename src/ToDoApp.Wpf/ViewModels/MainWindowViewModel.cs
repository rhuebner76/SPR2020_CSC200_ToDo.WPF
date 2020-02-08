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
            SaveCommand = new DelegateCommand(SaveTodoTaskFile);
            LoadCommand = new DelegateCommand(LoadTodoTaskFile, DelegateCommand.Always);
            ExitCommand = new ApplicationExitCommand();
        }

        public string Title { get; set; }

        public ICollection<TodoTaskViewModel> TodoTaskItems { get; set; }

        public ICommand AddTodoTaskCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand ExitCommand { get; }

        private void SaveTodoTaskFile(object obj)
        {
            System.IO.FileStream file = System.IO.File.Open("mytasks.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(file);

            foreach (var todoTaskItem in TodoTaskItems)
            {
                writer.WriteLine(todoTaskItem.Description);    
            }

            writer.Flush();
            writer.Dispose();
            file.Dispose();
        }

        private void LoadTodoTaskFile(object obj)
        {
            TodoTaskItems.Clear();
 
            System.IO.FileStream file = System.IO.File.Open("mytasks.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
            System.IO.StreamReader reader = new System.IO.StreamReader(file);

            while (reader.EndOfStream == false) 
            {
                TodoTask todoTask = new TodoTask();
                todoTask.Description = reader.ReadLine();

                TodoTaskItems.Add(new TodoTaskViewModel(todoTask));
            }
            
            reader.Dispose();
            file.Dispose();
        }

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
