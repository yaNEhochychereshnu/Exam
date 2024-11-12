using Demo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for AddNewStaffWindow.xaml
    /// </summary>
    public partial class AddNewStaffWindow : Window
    {
        public event EventHandler staffAdded;
        private readonly DemoContext _context;
        public AddNewStaffWindow()
        {
            InitializeComponent();
            _context = new DemoContext();
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                RoleComboBox.ItemsSource = _context.Roles.ToList();
                RoleComboBox.DisplayMemberPath = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке ролей: " +  ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Password.ToString();
                Role selectedRole = RoleComboBox.SelectedItem as Role;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(username)
                    || string.IsNullOrEmpty(password) || selectedRole == null)
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                User newUser = new User
                {
                    Name = name,
                    Surname = surname,
                    Login = username,
                    Password = password,
                    RoleId = selectedRole.Id,
                    Status = "active"
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                staffAdded?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Сотрудник успешно добавлен.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
