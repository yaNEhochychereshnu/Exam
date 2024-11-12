using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
    /// Interaction logic for ManageShiftsWindow.xaml
    /// </summary>
    public partial class ManageShiftsWindow : Window
    {
        private AddNewShiftWindow addNewShiftWindow;
        private readonly DemoContext _context;
        public ManageShiftsWindow()
        {
            InitializeComponent();
            _context = new DemoContext();
            LoadShiftsAsync();
            backButton.Click += (sender, e) =>
            {
                new AdminWindow().Show();
                Close();
            };
            addButton.Click += NewShiftButton_Click;
        }

        private async Task LoadShiftsAsync()
        {
            var shifts = await _context.Shifts.Include(s => s.ShiftUsers).ThenInclude(su => su.User).OrderByDescending(s => s.StartShift).ToListAsync();
            ShiftsGrid.ItemsSource = shifts;
        }

        private async void NewShiftButton_Click(object sender, RoutedEventArgs e)
        {
            if (addNewShiftWindow == null || !addNewShiftWindow.IsVisible)
            {
                addNewShiftWindow = new AddNewShiftWindow();
                addNewShiftWindow.Closed += async (s, args) =>
                {
                    addNewShiftWindow = null;
                    await LoadShiftsAsync();
                };
                addNewShiftWindow.Show();
            }
            else
            {
                addNewShiftWindow.Activate();
            }
        }
    }
}
