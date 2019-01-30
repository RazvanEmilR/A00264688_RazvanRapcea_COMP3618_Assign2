using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfAppClient.Testing;
using WpfAppClient.Validations;

namespace WpfAppClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdventureWorksLTContext _context = new DataAccess.AdventureWorksLTContext();
        public MainWindow()
        {
            InitializeComponent();
            
            var query = from c in _context.Customers where c.CustomerId == 5 select c;
            this.DataContext = query.FirstOrDefault();

            // var customer = query.FirstOrDefault();
            // customer.FirstName = null;
            //  customer.CustomerId = 3000;

            // InsertCustomer(customer);

            /*
            var customers = _context.Customers.ToList();
            foreach (Customer c in customers)
            {
                if (c.CustomerId == 55)
                {
                    c.FirstName = "DellaX";
                }
            }

            UpdateCustomers(customers);

            var cus = GetCustomerById(55);

            Console.WriteLine(cus.FirstName);
            */


            // DeleteCustomerById(6);

            var seeder = new Seeder();
            seeder.SeedTableEmployeesFirstTwenty(_context);
        }

        private void InsertCustomers(ICollection<Customer> customers)
        {
            foreach (Customer cust in customers)
            {
                var customerDb = _context.Customers.FirstOrDefault(c => c.CustomerId == cust.CustomerId);

                if (customerDb != null)
                {
                    Console.WriteLine("Error.Customer with id: " + cust.CustomerId + " you're trying to add already exists.");
                }
                else
                {
                    try
                    {
                        _context.Customers.Add(cust);
                        _context.SaveChanges();

                        Console.WriteLine("Customer with id= " + cust.CustomerId + " added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }
                }

            }
        }

        private void InsertCustomer(Customer customer)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

            if (customer == null)
            {
                if (CustomerValidation.Validate(customer))
                {
                    try
                    {
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine(CustomerValidation.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("Customer with the id= " + customer.CustomerId + " already exists in the database.");
            }          
        }

        private ICollection<Customer> GetCustomers()
        {
            ICollection<Customer> allCustomers = new Collection<Customer>();

            allCustomers = _context.Customers.ToList();

            return allCustomers;
        }

        private Customer GetCustomerById (int id)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.CustomerId == id);

            return customerDb;
        }

        private void UpdateCustomers (ICollection<Customer> customers)
        {
            try
            {
                foreach (Customer cust in customers)
                {
                    _context.Customers.Update(cust);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void UpdateCustomerById (int id)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.CustomerId == id);

            if (customerDb != null)
            {
                customerDb.MiddleName = "Doe";

                try
                {
                    _context.Customers.Update(customerDb);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Could not find custome with id= " + id + " in the table.");
            }
        }

        private void DeleteCustomers(ICollection<Customer> customersToDelete)
        {
            try
            {
                foreach (Customer cust in customersToDelete)
                {
                    // also erase references in other tables
                    var customerAddresses = _context.CustomerAddresses.Where(custAddr => custAddr.CustomerId == cust.CustomerId);
                    foreach (CustomerAddress custAddr in customerAddresses)
                    {
                        _context.CustomerAddresses.Remove(custAddr);
                    }

                    var salesOrderHeaders = _context.SalesOrderHeaders.Where(salesOrder => salesOrder.CustomerId == cust.CustomerId);
                    foreach (SalesOrderHeader soh in salesOrderHeaders)
                    {
                        _context.SalesOrderHeaders.Remove(soh);
                    }

                    //finally remove customer record
                    _context.Customers.Remove(cust);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }

        private void DeleteCustomerById (int id)
        {
            var customerDb = _context.Customers.FirstOrDefault(cust => cust.CustomerId == id);

            if (customerDb != null)
            {
                try
                {
                    // remove associated links
                    var customerAddreses = _context.CustomerAddresses.Where(custAddr => custAddr.CustomerId == id);
                    foreach (CustomerAddress custAddr in customerAddreses)
                    {
                        _context.CustomerAddresses.Remove(custAddr);
                    }

                    var salesOrderHeaders = _context.SalesOrderHeaders.Where(soh => soh.CustomerId == id);
                    foreach (SalesOrderHeader soh in salesOrderHeaders)
                    {
                        _context.SalesOrderHeaders.Remove(soh);
                    }

                    _context.Customers.Remove(customerDb);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                       
            }
            else
            {
                Console.WriteLine("Could not find customer with id= " + id + ".");
            }
        }
    }
}
