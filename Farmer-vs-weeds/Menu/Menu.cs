using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Farmer_vs_weeds.Farmers;

namespace Farmer_vs_weeds.Menu
{
    internal class Menu
    {
        // -- Properties --
        private static List<Farmer> Farmers = new List<Farmer>();

        // -- Methods --
        public static void DisplayMenu()
        {
            bool isMenuOn = true;

            while (isMenuOn)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Brawling Farmers ---\n");
                Console.WriteLine("1 - Add Farmer");
                Console.WriteLine("2 - Remove a Farmer");
                Console.WriteLine("3 - Show Farmer's list");
                Console.WriteLine("4 - Start a tournament");
                Console.WriteLine("5 - Start Singles Fight");
                Console.WriteLine("6 - Show previous winners\n");
                Console.WriteLine("0 - Quit");
                Console.ResetColor();

                MenuControls();
            }
            
            
            void MenuControls()
            {
                char input;
                input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case '1':
                    case '&':
                        Console.Clear();
                        isMenuOn = false;
                        AddFarmerMenu.AddFarmer();
                        break;
                    case '2':
                    case 'é':
                        Console.Clear();
                        isMenuOn = false;
                        RemoveFarmer.RemoveFarmerMenu();
                        break;
                    case '0':
                    case 'à':
                        Console.Clear();
                        isMenuOn = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
