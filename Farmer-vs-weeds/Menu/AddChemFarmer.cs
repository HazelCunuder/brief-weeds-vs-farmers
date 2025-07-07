using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmer_vs_weeds.Farmers;

namespace Farmer_vs_weeds.Menu
{
    internal class AddChemFarmer
    {
        public static void ChemFarmer()
        {
            string username;
            int hp = 0;
            int attackDices = 0;
            string types = "";

            bool validHp = false;
            bool validAttackDices = false;

            types = "Chem Farmer";
            Console.Clear();
            Console.Write("\nName: ");
            username = Console.ReadLine();

            while (!validHp)
            {
                Console.WriteLine("\nChoose between 40 and 90 life points ");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                if (inputUser < 40 || inputUser > 90)
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
                Console.WriteLine("\nChoose the number of attack dice between 6-9 d6");
                int inputUser = Convert.ToInt32(Console.ReadLine());

                if (inputUser < 6 || inputUser > 9)
                {
                    Console.WriteLine("Error,follow the instructions ");
                }
                else
                {
                    attackDices = inputUser;
                    break;
                }
            }

            Menu.FarmersList().Add(new ChemFarmer(username, hp, attackDices, types));
            Console.Clear();
            Console.WriteLine(
                $"\n{types} {username} create with {hp} HP and {attackDices} attack\n"
            );
        }
    }
}
