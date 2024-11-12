using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
    /// Interaction logic for AddNewShiftWindow.xaml
    /// </summary>
    public partial class AddNewShiftWindow : Window
    {
        private readonly DemoContext _context;
        public AddNewShiftWindow()
        {
            InitializeComponent();
            _context = new DemoContext();
            var staff = _context.Users.Include(u => u.Role).Where(u => u.Status == "active").ToList();
            StaffGrid.ItemsSource = staff;
        }

        private void CreateShiftButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStaff = StaffGrid.SelectedItems.Cast<User>().ToList();

            var startShiftDate = StartDatePicker.SelectedDate ?? DateTime.Today;
            var startShiftTime = TimeSpan.FromHours(int.Parse(((ComboBoxItem)StartHoursComboBox.SelectedItem).Content.ToString()))
                + TimeSpan.FromMinutes(int.Parse(((ComboBoxItem)StartMinutesComboBox.SelectedItem).Content.ToString()));
            var startShiftDateTime = startShiftDate.Add(startShiftTime);

            var endShiftDate = EndDatePicker.SelectedDate ?? DateTime.Today;
            var endShiftTime = TimeSpan.FromHours(int.Parse(((ComboBoxItem)EndHoursComboBox.SelectedItem).Content.ToString()))
                + TimeSpan.FromMinutes(int.Parse(((ComboBoxItem)EndMinutesComboBox.SelectedItem).Content.ToString()));
            var endShiftDateTime = endShiftDate.Add(endShiftTime);

            var newShift = new Shift
            {
                StartShift = startShiftDateTime,
                EndShift = endShiftDateTime,
                StatusShift = "prepare"
            };

            foreach (var staff in selectedStaff)
            {
                newShift.ShiftUsers.Add(new ShiftUser { User = staff });
            }

            MessageBox.Show("Смена успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
       
    }
}
