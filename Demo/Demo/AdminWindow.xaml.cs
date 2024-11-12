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

namespace Demo
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void ManageStaffButton_Click(object sender, RoutedEventArgs e)
        {
            var manageStaffWindow = new ManageStaff();
            Close();
            manageStaffWindow.Show();
        }

        private void ManageOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            var manageOrdersWindow = new ManageOrdersWindow();
            Close();
            manageOrdersWindow.Show();
        }

        private void ManageShiftsButton_Click(object sender, RoutedEventArgs e)
        {
            var manageShiftsWindow = new ManageShiftsWindow();
            Close();
            manageShiftsWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
