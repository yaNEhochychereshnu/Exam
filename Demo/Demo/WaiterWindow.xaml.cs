using Demo.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for WaiterWindow.xaml
    /// </summary>
    public partial class WaiterWindow : Window
    {
        private readonly DemoContext _context;
        public WaiterWindow()
        {
            InitializeComponent();
            _context = new DemoContext();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _context.Orders.Include(o => o.User).Include(o => o.OrderProducts).ThenInclude(op => op.Product).Where(o => o.Status == "ready").ToList();
            OrdersGrid.ItemsSource = orders;
        }

        private void PaidButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem != null && OrdersGrid.SelectedItem is Order selectedOrder)
            {
                selectedOrder.Status = "paid";
                _context.SaveChanges();
                LoadOrders();
                OrdersGrid.Items.Refresh();
            }
        }

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var newOrderButtonWindow = new AddNewOrderWindow();
            newOrderButtonWindow.ShowDialog();
            LoadOrders();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
