using System.Windows;
using System.Windows.Controls;
using ToDoApp.Wpf.Models;

namespace ToDoApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainWindowViewModel();
        }

        //private void OnAddTodoTaskButtonClick(object sender, RoutedEventArgs e)
        //{
        //    TodoTask item = new TodoTask();
        //    item.Description = TodoTaskNameText.Text;
        //    TodoTaskListView.Items.Add(item);
        //}

        private void OnRemoveTodoTaskButtonClick(object sender, RoutedEventArgs e)
        {
            int index = TodoTaskListView.SelectedIndex;
            if (CanRemoveTodoTask(index))
                TodoTaskListView.Items.RemoveAt(index);
        }

        private void OnTodoTaskListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = TodoTaskListView.SelectedIndex;
            RemoveTodoTaskButton.IsEnabled = CanRemoveTodoTask(index);
        }

        private bool CanRemoveTodoTask(int selectedIndex)
        {
            // selected index to remove cannot be less than 0 or greater than item count
            return (selectedIndex >= 0 && selectedIndex < TodoTaskListView.Items.Count);
        }
    }
}
