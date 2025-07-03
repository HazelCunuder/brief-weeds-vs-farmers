using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class DisplayList
    {
        public static void DisplayListMenu()
        {
            bool displayListMenuOn = true;
            int placeInList = 1;

            while (displayListMenuOn)
            {
                Console.WriteLine("--- List of Farmers ---\n");

                foreach (Farmer f in Menu.FarmersList())
                {
                    Console.WriteLine($"{placeInList} - {f.GetUsername()}");
                    placeInList++;
                }
                Console.WriteLine("\n0 - Go Back\n");

                ControlMenu();
            }

            void ControlMenu()
            {
                char input;

                input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case '0':
                    case 'à':
                        displayListMenuOn = false;
                        Console.Clear();
                        Menu.DisplayMenu();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
