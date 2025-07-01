using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen5.Views
{
    public static class OrderView
    {
        public static void ShowMsg(string msg) => Console.WriteLine(msg);

        public static string getValidInput(bool isNumeric = false)
        {
            string input;
            bool isValid = false;
            do
            {
                input = Console.ReadLine();
                if (isNumeric && double.TryParse(input, out double i) && !string.IsNullOrEmpty(input))
                {
                    isValid = true;
                }
                else if (!isNumeric && !string.IsNullOrEmpty(input))
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
