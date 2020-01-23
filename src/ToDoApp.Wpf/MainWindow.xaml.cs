using System.Windows;

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
            TodoTaskListView.Items.Add(TodoTaskNameText.Text);
        }
    }
}
