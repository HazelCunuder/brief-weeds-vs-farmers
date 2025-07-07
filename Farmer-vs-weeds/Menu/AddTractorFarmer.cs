using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmer_vs_weeds.Farmers;

namespace Farmer_vs_weeds.Menu
{
    internal class AddTractorFarmer
    {
        public static void TractorFarmer()
        {
            string username;
            int hp = 0;
            int attackDices = 0;
            string types = "";
            bool inTractor = true;

            bool validHp = false;
            bool validAttackDices = false;

            inTractor = true;
            types = "Tractor Farmer";
            Console.Clear();
            Console.Write("\nName: ");
            username = Console.ReadLine();

            while (!validHp)
            {
                Console.WriteLine("\nChoose between 100 and 150 life points ");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                if (inputUser < 100 || inputUser > 150)
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
                Console.WriteLine("\nChoose the number of attack dice between 1-3 d6");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                if (inputUser < 1 || inputUser > 3)
                {
                    Console.WriteLine("Error,follow the instructions ");
                }
                else
                {
                    attackDices = inputUser;
                    break;
                }
            }

            Menu.FarmersList().Add(new TractorFarmer(username, hp, attackDices, inTractor, types));
            Console.Clear();
            Console.WriteLine(
                $"\n{types} {username} create with {hp} HP and {attackDices} attack\n"
            );
        }
    }
}
