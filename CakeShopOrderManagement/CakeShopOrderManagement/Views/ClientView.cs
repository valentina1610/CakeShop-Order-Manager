using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExamen5.Models;

namespace PracticaExamen5.Views
{
    public static class ClientView
    {
        public static Client AddClient()
        {
            Console.Clear();
            Console.WriteLine("- ADD Client -");

            Console.WriteLine("Full name: ");
            string name = getValidInput();

            Console.WriteLine("Address: ");
            string address = getValidInput();

            Console.WriteLine("ID: ");
            string ID = getValidInput(true);

            Console.WriteLine("Email: ");
            string email = getValidInput(false, true);

            return new Client(name,address,ID,email);

        }

        public static void ShowClient(Client c)
        {
            Console.WriteLine($"Client ID: {c.ID}");
            Console.WriteLine($"Full name: {c.name} | Address: {c.address} | Email: {c.email}");
            Console.WriteLine("");
        }

        private static string getValidInput(bool isNumeric = false, bool isEmail = false)
        {
            string input;
            bool isValid = false;

            do
            {
                input = Console.ReadLine();

                if (isNumeric && !isEmail && double.TryParse(input, out double _) && !string.IsNullOrEmpty(input))
                {
                    isValid = true;
                }
                else if (!isNumeric && isEmail && !string.IsNullOrEmpty(input) && input.Contains("@"))
                {
                    isValid = true;
                }
                else if (!isNumeric && !isEmail && !string.IsNullOrEmpty(input))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid input, please try again !");
                }
            } while (!isValid);
            return input;
        }
    }
}
