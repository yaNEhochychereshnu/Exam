using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            using (var context = new DemoContext())
            {
                var user = context.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    switch (user.Role.Name)
                    {
                        case "admin":
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                            this.Close();
                            break;
                        case "cook":
                            CookWindow cookWindow = new CookWindow();
                            cookWindow.Show();
                            this.Close();
                            break;
                        case "waiter":
                            WaiterWindow waiterWindow = new WaiterWindow();
                            waiterWindow.Show();
                            this.Close();
                            break;
                        default:
                            MessageBox.Show("Ошибка! Такой роли не существует.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка! Неверный логин или пароль. Повторите попытку.");
                }
              
            }
        }
    }
}