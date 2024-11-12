using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Demo.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    /// <summary>
    /// Interaction logic for ManageOrdersWindow.xaml
    /// </summary>
    public partial class ManageOrdersWindow : Window
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        private readonly DemoContext _context;
        public ManageOrdersWindow()
        {
            InitializeComponent();
            _context = new DemoContext();
            LoadOrdersAsync();
            backButton.Click += (sender, e) =>
            {
                new AdminWindow().Show();
                Close();
            };
        }

        private async void LoadOrdersAsync()
        {
            Orders = await _context.Orders.Include(o => o.User).Include(o => o.OrderProducts).ThenInclude(op => op.Product).ToListAsync();
            OrdersGrid.ItemsSource = Orders;
        }
    }
}
