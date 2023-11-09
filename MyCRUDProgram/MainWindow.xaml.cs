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

namespace MyCRUDProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging;
        private Point startPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonCollapse_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;               
                Button1.Height = 80;
                Button1.Width = 80;
                Button2.Height = 80;
                Button2.Width = 80;
                Button3.Height = 80;
                Button3.Width = 80;
                searchImage.Margin= new Thickness(15, 37, 0, 0);
                ButtonCollapse.Height = 80;
                ButtonCollapse.Width = 80;
                ButtonFullscreen.Height = 70;
                ButtonFullscreen.Width = 70;
                ButtonClose.Height = 90;
                ButtonClose.Width = 90;

            }
            else
            {
                WindowState = WindowState.Normal;
                Button1.Height = 40;
                Button1.Width = 40;
                Button2.Height = 40;
                Button2.Width = 40;
                Button3.Height = 40;
                Button3.Width = 40;
                searchImage.Margin = new Thickness(15, 11, 0, 0);
                ButtonCollapse.Height = 40;
                ButtonCollapse.Width = 40;
                ButtonFullscreen.Height = 40;
                ButtonFullscreen.Width = 40;
                ButtonClose.Height = 48;
                ButtonClose.Width = 48;
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(this);
            Mouse.Capture(rect);
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            Mouse.Capture(null);
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point endPoint = e.GetPosition(this);
                double offsetX = endPoint.X - startPoint.X;
                double offsetY = endPoint.Y - startPoint.Y;

                Left += offsetX;
                Top += offsetY;
            }
        }
    }
}
