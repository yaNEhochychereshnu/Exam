using Demo.Models;
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
    /// Interaction logic for AddNewOrderWindow.xaml
    /// </summary>
    public partial class AddNewOrderWindow : Window
    {
        private readonly DemoContext _context;
        public AddNewOrderWindow()
        {
            InitializeComponent();
            _context = new DemoContext();
            LoadUsers();
            var products = _context.Products.ToList();
            ProductsGrid.ItemsSource = products;
        }

        private void LoadUsers()
        {
            UserComboBox.ItemsSource = _context.Users.Where(u => u.Status == "active").ToList();
            UserComboBox.DisplayMemberPath = "Name";
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = ProductsGrid.SelectedItems.Cast<Product>().ToList();

            var orderDate = OrderDatePicker.SelectedDate ?? DateTime.Now;
            var orderTime = TimeSpan.FromHours(int.Parse(((ComboBoxItem)OrderHoursComboBox.SelectedItem).Content.ToString())) +
                TimeSpan.FromMinutes(int.Parse(((ComboBoxItem)OrderMinutesComboBox.SelectedItem).Content.ToString()));
            var orderDateTime = orderDate.Add(orderTime);

            string place = PlaceTextbox.Text;
            User selectedUser = UserComboBox.SelectedItem as User;
            int countPerson = int.Parse(CountPersonTextbox.Text);

            var newOrder = new Order
            {
                Date = orderDateTime,
                Status = "accepted",
                UserId = selectedUser.Id,
                Place = place,
                CountPerson = countPerson,
            };

            foreach (var product in selectedProducts)
            {
                newOrder.OrderProducts.Add(new OrderProduct { Product = product });
            }
            
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            MessageBox.Show("Заказ успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
