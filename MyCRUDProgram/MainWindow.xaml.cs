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
            }
            else
            {
                WindowState = WindowState.Normal;
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
