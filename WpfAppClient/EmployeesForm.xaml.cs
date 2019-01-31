using DataAccess;
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

namespace WpfAppClient
{
    /// <summary>
    /// Interaction logic for EmployeesForm.xaml
    /// </summary>
    public partial class EmployeesForm : Window
    {
        private AdventureWorksLTContext _context = new DataAccess.AdventureWorksLTContext();

        public EmployeesForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var allEmployees = _context.Employees.ToList();

            dataGrid1.ItemsSource = allEmployees;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee emp = (Employee)dataGrid1.SelectedItem;

            var employeeWindow = new EmployeeForm(emp, _context);
            employeeWindow.ShowDialog();
        }
    }
}
