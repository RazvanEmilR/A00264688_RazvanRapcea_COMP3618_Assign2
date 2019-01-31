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
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {

        public bool TextWasChanged = false;

        AdventureWorksLTContext _context;

        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(Employee emp, AdventureWorksLTContext context)
        {
            InitializeComponent();

            this.DataContext = emp;
            this._context = context;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime birthDate = DateTime.Parse(textBoxHireDate.Text);
            DateTime hireDate = DateTime.Parse(textBoxHireDate.Text);

            Employee updatedEmp = new Employee
            {
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                HomePhone = textBoxHomePhoneNumber.Text,
                BirthDate = birthDate,
                HireDate = hireDate,
                Address = textBoxAddress.Text,
                Notes = textBoxNotes.Text
            };

            try
            {
                _context.Employees.Update(updatedEmp);
                labelErrorMessage.Content = "SUCCESS, RECORD UPDATED";
            }
            catch (Exception ex)
            {
                labelErrorMessage.Content = ex.InnerException.Message;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = false;
            labelErrorMessage.Content = "";

            textBoxFirstName.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            textBoxLastName.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);         
            textBoxHomePhoneNumber.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            textBoxBirthDate.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            textBoxHireDate.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            textBoxAddress.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            textBoxNotes.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextWasChanged = true;
            btnSave.IsEnabled = true;
        }
    }
}
