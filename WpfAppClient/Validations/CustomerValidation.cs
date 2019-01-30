using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppClient.Validations
{
    public class CustomerValidation
    {
        private static List<string> errors;

        static CustomerValidation()
        {
            errors = new List<string>();
        }

        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string line in errors)
                {
                    message += line + "\r\n";
                }

                return message;
            }
        }

        public static bool Validate(Customer customer)
        {
            bool success = true;
            errors.Clear();

            if (string.IsNullOrEmpty(customer.FirstName))
            {
                errors.Add("First name cannot be null or empty.");
                success = false;
            }

            if (string.IsNullOrEmpty(customer.LastName))
            {
                errors.Add("Last name cannot be null or empty.");
                success = false;
            }

            if (string.IsNullOrEmpty(customer.PasswordHash))
            {
                errors.Add("Password hash cannot be null or empty.");
                success = false;
            }

            if (string.IsNullOrEmpty(customer.PasswordSalt))
            {
                errors.Add("Password salt cannot be null or empty.");
                success = false;
            }

            if (string.IsNullOrEmpty(customer.LastName))
            {
                errors.Add("Last name cannot be null or empty.");
                success = false;
            }

            if (customer.Rowguid == null)
            {
                errors.Add("Rowguid cannot be null.");
                success = false;
            }


            return success;
        }
    }
}
