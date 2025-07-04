namespace Farmer_vs_weeds.Menu
{
    internal class AddFarmerMenu
    {
        // -- Methods --
        public static void AddFarmer()
        {
            string username;
            int hp = 0;
            int attackDices = 0;
            bool inTractor = false;
            string types = "";

            bool addFarmer = true;
            bool validHp = false;
            bool validAttackDices = false;

            while (addFarmer)
            {
                Console.WriteLine("--- Add a Farmer ---\n");

                Console.WriteLine("Create new Farmer\n");

                Console.WriteLine("1 - Classic Farmer");
                Console.WriteLine("2 - Chem Farmer");
                Console.WriteLine("3 - Tractor Farmer\n");
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

                        Menu.FarmersList().Add(new Farmer(username, hp, attackDices,types));
                        Console.Clear();
                        Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                        break;

                    case '2':
                    case 'é':

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

                        Menu.FarmersList().Add(new Farmer(username, hp, attackDices,types));
                        Console.Clear();
                        Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                        break;

                    case '3':
                    case '"':
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

                        Menu.FarmersList().Add(new Farmer(username, hp, attackDices,types));
                        Console.Clear();
                        Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                        break; ;

                    case '0':
                    case 'à':

                        Console.WriteLine("\nReturning to main menu...");
                        addFarmer = false;
                        Console.Clear();
                        Menu.DisplayMenu();
                        break;

                }
            }
        }
    }
}
