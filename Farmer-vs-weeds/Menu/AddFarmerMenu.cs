using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            string type = "";

            bool addFarmer = true;
            bool creatingCharacter = true;
            bool validHp = false;
            bool validAttackDices = false;

            bool isMenuOn = true;

            while (addFarmer)
            {
                Console.WriteLine("--- Add a Farmer ---\n");

                Console.WriteLine("Create new Farmer\n");

                Console.WriteLine("1 - Classic Farmer");
                Console.WriteLine("2 - Chemical Farmer");
                Console.WriteLine("3 - Automatic Farmer\n");
                Console.WriteLine("0 - Go Back");

                Console.WriteLine("Choose your Farmer: 1-3");

                choiceFarmer();
            }
            
            void choiceFarmer()
            {
                char inputChoice;
                inputChoice = Console.ReadKey().KeyChar;

                switch (inputChoice)
                {
                    case '1':
                    case '&':
                        type = "Classic Farmer";

                        Console.Write("\nName: ");
                        username = Console.ReadLine();

                        while (!validHp)
                        {
                            Console.WriteLine("\nChoose between 70 and 120 life points ");
                            int inputUser = Convert.ToInt32(Console.ReadLine());

                            if (inputUser < 70 || inputUser > 120)
                            {
                                Console.WriteLine("Erreur,follow the instructions ");                               
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
                                Console.WriteLine("Erreur,follow the instructions ");
                            }
                            else
                            {
                                attackDices = inputUser;
                                break;
                            }
                        }
                       
                        Menu.FarmersList().Add(new Farmer(username, hp, attackDices));
                        Console.WriteLine($"\n{type} {username} create with {hp} HP and {attackDices} attack\n");
                        break;

                    case '2':
                    case 'é':

                        type = "Chemical Farmer";

                        Console.Write("\nName: ");
                        username = Console.ReadLine();

                        while (!validHp)
                        {
                            Console.WriteLine("\nChoose between 40 and 90 life points ");
                            int inputUser = Convert.ToInt32(Console.ReadLine());

                            if (inputUser < 40 || inputUser > 90)
                            {
                                Console.WriteLine("Erreur,follow the instructions ");
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
                                Console.WriteLine("Erreur,follow the instructions ");
                            }
                            else
                            {
                                attackDices = inputUser;
                                break;
                            }
                        }

                        Menu.FarmersList().Add(new Farmer(username, hp, attackDices));
                        Console.WriteLine($"\n{type} {username} create with {hp} HP and {attackDices} attack\n");
                        break;

                    case '3':
                    case '"':

                        Console.Write("Name: ");
                        username = Console.ReadLine();
                        break;

                    case '0':
                    case 'à':
                        Console.WriteLine("\nReturning to main menu...");
                        addFarmer = false;
                        break;

                }
            }
        }
    }
}
