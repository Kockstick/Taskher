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
    /// Логика взаимодействия для MyTask.xaml
    /// </summary>
    public partial class MyTask : Border
    {
        public MyTask()
        {
            InitializeComponent();

            EditMyTask(true);
        }

        private void Title_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TitleMask.Width = textBox.ActualWidth;
        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TitleMask.Width = textBox.ActualWidth;
        }

        private void MyTaskBorder_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            BorderMask.Width = MyTaskBorder.ActualWidth;
            BorderMask.Height = MyTaskBorder.ActualHeight;
        }

        private void EditMyTask(bool isEdit)
        {
            if (isEdit)
            {
                Background = new SolidColorBrush(Colors.WhiteSmoke);
                Title.IsReadOnly = false;
                Text.IsReadOnly = false;
                Title.Focus();
            }
            else
            {
                Title.IsReadOnly = true;
                Text.IsReadOnly = true;
                Background = new SolidColorBrush(Colors.White);
            }
            
        }
    }
}
