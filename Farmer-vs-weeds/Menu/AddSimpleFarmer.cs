using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class AddSimpleFarmer
    {
        public static void SimpleFarmer()


        {
            string username;
            int hp = 0;
            int attackDices = 0;
            string types = "";
            bool inTractor = false;
            int menuSelect = 4;

            bool addFarmer = true;
            bool validHp = false;
            bool validAttackDices = false;

            Console.Clear();
            types = "Classic Farmer";
            Console.Clear();
            Console.Write("\nName: ");
            username = Console.ReadLine();

            while (!validHp)
            {
                Console.WriteLine("\nChoose between 70 and 120 life points ");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                if (inputUser < 70 || inputUser > 120)
                {
                    Console.WriteLine("Error,follow the instructions ");
                }
                else
                {
                    hp = inputUser;
                    break;
                }

            }
            while (!validAttackDices)
            {
                Console.WriteLine("\nChoose the number of attack dice between 4-6 d6");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                if (inputUser < 3 || inputUser > 6)
                {
                    Console.WriteLine("Error,follow the instructions ");
                }
                else
                {
                    attackDices = inputUser;
                    break;
                }
            }

            Menu.FarmersList().Add(new Farmer(username, hp, attackDices, types));
            Console.Clear();
            Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");


        }
    }
}
