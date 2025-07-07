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
            string types = "";
            bool inTractor = false;
            int menuSelect = 4;

            bool addFarmer = true;
            bool validHp = false;
            bool validAttackDices = false;

            string[] display = new string[]
            {
                "--- Add a Farmer ---",
                " ",
                "Create new Farmer",
                " ",
                "1 - Classic Farmer",
                "2 - Chem Farmer",
                "3 - Tractor Farmer",
                " ",
                "0 - Go Back",
            };

            while (addFarmer)
            {
                Console.Clear();
                DisplayFarmer();
                
                MenuControls();
            }

            void MenuControls()
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();


                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < 8)
                {
                    menuSelect++;
                    Console.Clear();
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect > 4)
                {
                    menuSelect--;
                    Console.Clear();
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 4:
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
                            break;

                        case 5:

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

                            Menu.FarmersList().Add(new Farmer(username, hp, attackDices, types));
                            Console.Clear();
                            Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                            break;

                        case 6:

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

                            Menu.FarmersList().Add(new Farmer(username, hp, attackDices, types));
                            Console.Clear();
                            Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                            break;

                        case 8:

                            Console.WriteLine("\nReturning to main menu...");
                            addFarmer = false;
                            Console.Clear();
                            Menu.DisplayMenu();
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
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
                            break;

                        case ConsoleKey.D2:

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

                            Menu.FarmersList().Add(new Farmer(username, hp, attackDices, types));
                            Console.Clear();
                            Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                            break;

                        case ConsoleKey.D3:


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

                            Menu.FarmersList().Add(new Farmer(username, hp, attackDices, types));
                            Console.Clear();
                            Console.WriteLine($"\n{types} {username} create with {hp} HP and {attackDices} attack\n");
                            break;

                        case ConsoleKey.D0:

                            Console.WriteLine("\nReturning to main menu...");
                            addFarmer = false;
                            Console.Clear();
                            Menu.DisplayMenu();
                            break;

                        default:
                            Console.Clear();
                            break;
                    }
                }
            }

            void DisplayFarmer()
            {
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                int menuHeight = display.Length;
                int verticalPadding = (consoleHeight - menuHeight) / 2;

                // -- Add blank lines for vertical centering --
                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < display.Length; i++)
                {
                    int leftPadding = (consoleWidth - display[i].Length) / 2;

                    Console.SetCursorPosition(leftPadding < 0 ? 0 : leftPadding, Console.CursorTop);

                    if (i == menuSelect)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(display[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(display[i]);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
