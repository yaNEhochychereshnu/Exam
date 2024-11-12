using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManageStaff.xaml
    /// </summary>
    public partial class ManageStaff : Window
    {
        private ObservableCollection<User> _staff;
        private readonly DemoContext _context;
        public ManageStaff()
        {
            InitializeComponent();
            _context = new DemoContext();
            LoadStaff();
            backButton.Click += (sender, e) =>
            {
                new AdminWindow().Show();
                Close();
            };
        }

        private void LoadStaff()
        {
            _staff = new ObservableCollection<User>(_context.Users.Include(u => u.Role).Where(u => u.Status == "active").ToList());
            StaffGrid.ItemsSource = _staff;
        }

        private void FireButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaffGrid.SelectedItem != null)
            {
                var selectedStaff = StaffGrid.SelectedItem as User;

                using (var context = new DemoContext())
                {
                    var staffToUpdate = context.Users.FirstOrDefault(u => u.Id == selectedStaff.Id);
                    if (staffToUpdate != null)
                    {
                        staffToUpdate.Status = "inactive";
                        context.SaveChanges();
                        _staff.Remove(selectedStaff);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для увольнения.");
            }
        }

        private void AddNewStaffButton_Click(object sender, RoutedEventArgs e)
        {
            var addNewStaffWindow = new AddNewStaffWindow();
            addNewStaffWindow.ShowDialog();
            LoadStaff();
        }
    }
}
