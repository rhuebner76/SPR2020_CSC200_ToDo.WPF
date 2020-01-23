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
        }

        private void OnAddTodoTaskButtonClick(object sender, RoutedEventArgs e)
        {
            TodoTask item = new TodoTask();
            item.Description = TodoTaskNameText.Text;
            TodoTaskListView.Items.Add(item);
        }

        private void OnRemoveTodoTaskButtonClick(object sender, RoutedEventArgs e)
        {
            Button removeTodoTaskButton = (Button)sender;
            TodoTask item = (TodoTask)removeTodoTaskButton.DataContext;
            TodoTaskListView.Items.Remove(item);
        }
    }
}
