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
using System.Windows.Shapes;

namespace Taskher
{
    /// <summary>
    /// Логика взаимодействия для CompletedTask.xaml
    /// </summary>
    public partial class CompletedTask : Border
    {
        public CompletedTask()
        {
            InitializeComponent();
        }

        public CompletedTask(MyTask task) : this()
        {
            Title.Content = task.Title.Text;
            Text.Text = task.Text.Text;
            Text.Height = task.Text.ActualHeight;
        }

        public CompletedTask(string title, string text) : this()
        {
            Title.Content = title;
            Text.Text = text;
        }
    }
}
