using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class Tournament
    {



        public static void TournamentMenu()
        {   
            Console.Clear();
            Console.WriteLine("--- Tournament Start---");

            List<Farmer> Farmers = Menu.FarmersList();

            int totalFarmers = 0;

            foreach(Farmer total in Farmers)
            {
                totalFarmers++;
            }

            if (totalFarmers < 2)
            {
                Console.Write("\nYou need at least 2 farmers to start a tournament\n");
                Console.WriteLine("\nPress any key to return menu");
                Console.ReadKey();
                Console.Clear();
                Menu.DisplayMenu();
            }




        }
    }
}
