using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Wpf.ViewModels
{
    using Models;

    class TodoTaskViewModel : INotifyPropertyChanged
    {
        private TodoTask TodoTask { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets and sets todo task completed status
        /// </summary>
        public bool IsCompleted
        {
            get { return this.TodoTask.IsCompleted; }
            set
            {
                this.TodoTask.IsCompleted = value;
                this.NotifyPropertyChanged(nameof(IsCompleted));
            }
        }

        /// <summary>
        /// Gets and sets todo task description
        /// </summary>
        public string Description
        {
            get
            {
                return this.TodoTask.Description;
            }
            set
            {
                this.TodoTask.Description = value;
                this.NotifyPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Default Constructor which takes a todo task model 
        /// </summary>
        /// <param name="todoTask"></param>
        public TodoTaskViewModel(TodoTask todoTask)
        {
            this.TodoTask = todoTask;
        }

        /// <summary>
        /// Dispatch Notification that a property value has changed
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler == null) return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
