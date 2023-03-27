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
        private MainWindow parent;
        public MyTask(MainWindow main)
        {
            InitializeComponent();

            parent = main;

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
                EndEditImage.Visibility = Visibility.Visible;
                EditImage.Visibility= Visibility.Hidden;
                Title.IsReadOnly = false;
                Text.IsReadOnly = false;
                Title.Focus();
            }
            else
            {
                EndEditImage.Visibility = Visibility.Hidden;
                EditImage.Visibility = Visibility.Visible;
                Title.IsReadOnly = true;
                Text.IsReadOnly = true;
                Background = new SolidColorBrush(Colors.White);
            }
            
        }

        private void EditImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var img = sender as Image;
            if (img.Tag.ToString() == "edit")
                EditMyTask(true);
            else
                EditMyTask(false);
        }

        private double rangeScale = 5;
        private void EditImage_MouseEnter(object sender, MouseEventArgs e)
        {
            var img = sender as Image;
            img.Width = img.ActualWidth + rangeScale;
            double m = img.Margin.Right;
            img.Margin = new Thickness(m - rangeScale / 2);
        }

        private void EditImage_MouseLeave(object sender, MouseEventArgs e)
        {
            var img = sender as Image;
            img.Width = img.ActualWidth - rangeScale;
            double m = img.Margin.Right;
            img.Margin = new Thickness(m + rangeScale / 2);
        }

        private void Complete_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (parent == null)
                return;

            parent.CompleteTask(this);
        }
    }
}
