using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Taskher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
            //аыка
        }

        public void CompleteTask(MyTask myTask)
        {
            if (!ActivTasksPanel.Children.Contains(myTask))
                return;

            ActivTasksPanel.Children.Remove(myTask);
            CompletedTasks.Children.Add(new CompletedTask(myTask));
        }

        private double rangeScale = 5;
        private void Scale_MouseEnter(object sender, MouseEventArgs e)
        {
            var img = sender as FrameworkElement;
            img.Width = img.ActualWidth + rangeScale;
            double m = img.Margin.Right;
            img.Margin = new Thickness(m - rangeScale / 2);
        }

        private void Scale_MouseLeave(object sender, MouseEventArgs e)
        {
            var img = sender as FrameworkElement;
            img.Width = img.ActualWidth - rangeScale;
            double m = img.Margin.Right;
            img.Margin = new Thickness(m + rangeScale / 2);
        }

        private void AddMyTask_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MyTask myTask = new MyTask(this);
            ActivTasksPanel.Children.Add(myTask);
        }
    }
}
