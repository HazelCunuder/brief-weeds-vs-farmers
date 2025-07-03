using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class Menu
    {
        // -- Properties --

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
                Console.WriteLine("5 - Show previous winners\n");
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
                    case '0':
                    case 'à':
                        Console.Clear();
                        isMenuOn = false;
                        break;
                }
            }
        }

        private List<Farmer> Farmer = new List<Farmer>();

        // -- Methods --

        public void AddFarmer()
        {
            Console.WriteLine("Create new Farmer")

            Console.WriteLine("Name: ")
                Console.ReadLine
        }
    }
}
