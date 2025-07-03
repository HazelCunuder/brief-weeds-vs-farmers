using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class AddFarmerMenu
    {
        public static void AddFarmer()
        {
            string username;
            int hp = 0;
            int attackDices = 0;
            bool inTractor = false;

            bool addFarmer = true;
            bool creatingCharacter = true;

            while (addFarmer)
            {
                Console.WriteLine("--- Add a Farmer ---\n");

                Console.WriteLine("Create new Farmer\n");

                Console.WriteLine("1 - Classic Farmer");
                Console.WriteLine("2 - Chemical Farmer");
                Console.WriteLine("3 - Automatic Farmer\n");
                Console.WriteLine("0 - Go Back");

                Console.WriteLine("Choose your Farmer: 1-3");
            }


            int inputChoice = Convert.ToInt32(Console.ReadLine());

            switch (inputChoice)
            {
                case '1':
                case '&':

                    Console.Write("Name: ");
                    username = Console.ReadLine();
                    break;

                case '2':
                case 'é':

                    Console.Write("Name: ");
                    username = Console.ReadLine();
                    break;

                case '3':
                case '"':

                    Console.Write("Name: ");
                    username = Console.ReadLine();
                    break;

                case '0':
                case 'à':

                    break;
            }

        }
    }
}
