using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClient.Testing
{
    public class Seeder
    {
        private Random rnd;
        public Seeder()
        {
            rnd = new Random();
        }

        public void SeedTableEmployeesFirstTwenty(AdventureWorksLTContext _context)
        {
            int employeeIdCounter = 0;
            bool success = true;

            string[] firstNames = { "John", "Doe", "Mary", "Jane", "Andrew", "Smith", "Bob", "Lucy", "Jen", "Mike",
                                    "Tracy", "Brooke",  "Linda", "Robertson", "Olivia", "Amelia", "Brenda", "Jacob", "Charlie", "George"};

            string[] lastNames = {"Johnson", "Hall", "King", "Rogers", "Reed", "Cook", "Morgan", "Bell","Murphy", "Bailey", "Rivera","Jenkins",
                                 "Perry", "Powell", "Wilson", "Moore", "Taylor", "Long", "Patterson", "Hughes" };

            string[] titles = { "Mr", "Ms", "Doctor" };

            string[] titlesOfCourtesy = { "Count of Champagne", "Duke of Nottingham", "Duchess of Wales", "Duke of York" };
        
            string[] addresses = { "2444 Cunningham Court", "2564 Valley View Drive", "4677 Hillcrest Lane", "999 Jail Drive", "1188 Harrison Street",
                "4521 Clement Street", "1588 Petunia Way", "4303 Stanley Avenue" ,"726 Science Center Drive", "1378 Melody Lane", "4115 American Drive",
                "2283 Carriage Court", "3859 Calvin Street", "3497 George Street", "4858 Washington Street", "4824 Woodland Drive",
                "4889 Ruckman Road", "2192 Small Street", "420 Highland View Drive", "4119 Colony Street"};

            string[] cities = { "Hamburg", "Medellin", "Omsk", "Nagoya", "Zhongshan", "Suzhou", "Daejeon", "Toronto", "Busan", "Havana",
                                 "Lusaka", "Philadelphia", "New York", "Chicago", "Toulouse", "Denia", "Madrid", "Valencia", "Paris", "Bucharest" };

            string[] notes = { "Nullam", "lorem", "tortor", "iaculis", "ullamcorper", "eget", "posuere", "Donec", "lectus", "posuere",
                              "Praesent", "tincidunt", "Maecenas", "sapien", "congue", "accumsan", "faucibus", "Proin", "mattis", "dolor"};

            while (employeeIdCounter != 20)
            {
                var firstNameIndex = GenerateRandomIntOfMaxValue(20);
                var lastNameIndex = GenerateRandomIntOfMaxValue(20);
                var titleIndex = GenerateRandomIntOfMaxValue(3);              
                var addressIndex = GenerateRandomIntOfMaxValue(20);
                var cityIndex = GenerateRandomIntOfMaxValue(20);
                var noteIndex = GenerateRandomIntOfMaxValue(20);
                var randomBirthdate = GenerateRandomDate();
                var randomHiredate = GenerateRandomDate();

                string courtesyTitle;
                int titleOfCourtesyIndex;

                bool hasTitle = GenerateRandomIntOfMaxValue(2) == 1 ? true : false;

                if (hasTitle)
                {                  
                    titleOfCourtesyIndex = GenerateRandomIntOfMaxValue(4);
                    courtesyTitle = titlesOfCourtesy[titleOfCourtesyIndex];
                }
                else
                {
                    courtesyTitle = null;
                }

                var employeeToAdd = new Employee
                {        
                    FirstName = firstNames[firstNameIndex],
                    LastName = lastNames[lastNameIndex],
                    Title = titles[titleIndex],
                    TitleOfCourtesy = courtesyTitle,
                    BirthDate = randomBirthdate,
                    HireDate = randomHiredate,
                    Address = addresses[addressIndex],
                    City = cities[cityIndex],       
                    Notes = notes[noteIndex],  
                };

                var employeeDb = _context.Employees.FirstOrDefault(emp => emp.EmployeeId == employeeIdCounter );
             
               
                if (employeeDb == null)
                {
                   _context.Employees.Add(employeeToAdd);                      
                }
                else
                {
                   Console.WriteLine("Employee with id= " + employeeIdCounter + " already exists in database. ");
                   success = false;
                }
                                          
                employeeIdCounter++;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                success = false;
            }

            if (success)
            {
                Console.WriteLine("First 20 records have been seeded into the table.");
            }
            else
            {
                Console.WriteLine("There were errors");
            }
        }

        private int GenerateRandomIntOfMaxValue(int maxValue)
        {
            return rnd.Next(0, maxValue);
        }

        private DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(rnd.Next(range));
        }
    }
}
