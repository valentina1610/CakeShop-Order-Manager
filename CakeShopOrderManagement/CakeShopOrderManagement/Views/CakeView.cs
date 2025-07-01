using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExamen5.Models;

namespace PracticaExamen5.Views
{
    public static class CakeView
    {
        public static List<Cake> AddCakeList()
        {
            Console.Clear();
            Console.WriteLine("- ADD CAKE LIST -");
            List<Cake> tempList = new();
            string input;
            int i = 0;

            do
            {
                try
                {
                    Console.WriteLine($"- Cake: {i + 1}");
                    i++;

                    Console.WriteLine("Type: ");
                    string type = getValidInput();

                    Console.WriteLine("Flavor: ");
                    string flavor = getValidInput();

                    Console.WriteLine("Price: ");
                    double price = double.Parse(getValidInput(true));

                    Console.Write("Want to add another cake? (y/n): ");
                    input = getValidInput(false, true);

                    tempList.Add(new Cake(type, flavor, price));
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[ERROR]: {ex.Message}");
                    Console.WriteLine("Press a key to return");
                    Console.ReadKey();
                    return null;
                }
            } while (input != "n");
            return tempList;
        }

        public static void ShowCakeList(List<Cake> list)
        {
            int i = 0;
            

            foreach (var c in list)
            {
                Console.WriteLine($"~ Cake {i + 1}: ");
                i++;
                Console.WriteLine($"Type: {c.type} | Flavor: {c.flavor} | Price: {c.price}$ | Price(IVA): {c.PriceWithIVA()}$");
            }

        }

        private static string getValidInput(bool isNumeric = false, bool isYOrN = false)
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
                else if (!isNumeric && isYOrN && !string.IsNullOrEmpty(input) && (input.Contains("y") || (input.Contains("n"))))
                {
                    isValid = true;
                }
                else if (!isNumeric && !isYOrN && !string.IsNullOrEmpty(input))
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
