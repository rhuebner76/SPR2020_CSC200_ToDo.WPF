using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace ToDoApp.Wpf.ViewModels
{
    using Models;

    class TodoTaskListViewModel
    {
        private ObservableCollection<TodoTaskViewModel> TodoTasks { get; }

        public IEnumerable<TodoTaskViewModel> Items { get { return TodoTasks; } }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public TodoTaskListViewModel()
        {
            this.TodoTasks = new ObservableCollection<TodoTaskViewModel>();
            this.AddCommand = new DelegateCommand(Add, CanAdd);
            this.RemoveCommand = new DelegateCommand(Remove, CanRemove);
        }

        private void Add(object value)
        {
            var model = new TodoTask();
            model.Description = value.ToString();
            var viewModel = new TodoTaskViewModel(model);
            TodoTasks.Add(viewModel);
        }

        private bool CanAdd(object value)
        {
            return value != null 
                && !string.IsNullOrEmpty(value.ToString());
        }

        private void Remove(object value)
        {
            var viewModel = value as TodoTaskViewModel;
            if (viewModel == null) return;
            TodoTasks.Remove(viewModel);
        }

        private bool CanRemove(object value)
        {
            return value != null 
                && value is TodoTaskViewModel;
        }
    }
}
