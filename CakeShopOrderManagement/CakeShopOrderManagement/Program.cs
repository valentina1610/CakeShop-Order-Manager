using System;
using PracticaExamen5.Controllers;

namespace PracticaExamen5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int salida = 0;
            OrderController controller = new();
            do
            {
                Console.Clear();

                GetMessaggeAndColor("- MENU CAKE SHOP -", ConsoleColor.Cyan);

                GetMessaggeAndColor("1.", ConsoleColor.Magenta, false);
                GetMessaggeAndColor("Add order");

                GetMessaggeAndColor("2.", ConsoleColor.Magenta, false);
                GetMessaggeAndColor("Show orders");

                GetMessaggeAndColor("3.", ConsoleColor.Magenta, false);
                GetMessaggeAndColor("Update order");

                GetMessaggeAndColor("4.", ConsoleColor.Magenta, false);
                GetMessaggeAndColor("Delete order");

                GetMessaggeAndColor("0.", ConsoleColor.Magenta, false);
                GetMessaggeAndColor("Exit");

                GetMessaggeAndColor("Enter an option: ", ConsoleColor.Cyan, false);
                Console.ForegroundColor = ConsoleColor.Magenta;

                try
                {
                    salida = int.Parse(Console.ReadLine());
                    switch (salida)
                    {
                        case 1: controller.AddOrder(); break;
                        case 2: controller.ShowOrder(); Console.ReadKey(); break;
                        case 3: controller.UpdateOrder(); Console.ReadKey(); break;
                        case 4: controller.DeleteOrder(); Console.ReadKey(); break;
                        default: Console.WriteLine("[ERROR]: Invalid input");
                            Console.WriteLine("Press a key to return");
                            Console.ReadKey();
                            break;
                    }
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR]: {ex.Message}");
                    salida = 1;
                    Console.WriteLine("Press a key to return");
                    Console.ReadKey();
                }

            } while (salida != 0);
        }

        private static void GetMessaggeAndColor(string msg, ConsoleColor color = ConsoleColor.White, bool lineBreak = true)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            if (lineBreak)
                Console.WriteLine("");
        }
    }
}
