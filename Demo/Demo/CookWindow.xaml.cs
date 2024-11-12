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
    /// Interaction logic for CookWindow.xaml
    /// </summary>
    public partial class CookWindow : Window
    {
        private readonly DemoContext _context;
        public CookWindow()
        {
            InitializeComponent();;
            _context = new DemoContext();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _context.Orders.Include(o => o.User).Include(o => o.OrderProducts).ThenInclude(op => op.Product).Where(o => o.Status == "accepted" || o.Status == "cooking").ToList();
            OrdersGrid.ItemsSource = orders;
        }

        private void CookingButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem != null && OrdersGrid.SelectedItem is Order selectedOrder)
            {
                selectedOrder.Status = "cooking";
                _context.SaveChanges();
                LoadOrders();
                OrdersGrid.Items.Refresh();
            }
        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem != null && OrdersGrid.SelectedItem is Order selectedOrder)
            {
                selectedOrder.Status = "ready";
                _context.SaveChanges();
                LoadOrders();
                OrdersGrid.Items.Refresh();
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
