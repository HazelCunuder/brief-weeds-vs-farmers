using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class RemoveFarmer
    {
        public static void RemoveFarmerMenu()
        {
            bool removeMenuOn = true;
            int placeInList = 1;

            while (removeMenuOn)
            {
                Console.WriteLine("--- Remove Farmers ---\n");

                foreach (Farmer f in Menu.FarmersList())
                {
                    Console.WriteLine($"{placeInList} - {f.GetUsername()}");
                    placeInList++;
                }
                Console.WriteLine("\n0 - Go Back\n");

                Console.Write("Which Farmer do you want to remove? (Input 0 to go back)");
                ControlMenu();
            }

            void ControlMenu()
            {
                int input;

                input = Convert.ToInt32(Console.ReadLine());

                if (input != 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        Menu.FarmersList()[input - 1].GetUsername() + " has been removed.\n"
                    );
                    Console.ResetColor();
                    Menu.FarmersList().RemoveAt(input - 1);
                }
                else
                {
                    removeMenuOn = false;
                    Console.Clear();
                    Menu.DisplayMenu();
                }
            }
        }
    }
}
