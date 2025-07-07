using System;

namespace Farmer_vs_weeds.Menu
{
    internal class RemoveFarmer
    {
        public static void RemoveFarmerMenu()
        {
            bool removeMenuOn = true;

            // Helper method to write centered text
            void WriteCentered(string text, bool newline = true)
            {
                int leftPadding = (Console.WindowWidth - text.Length) / 2;
                if (leftPadding < 0) leftPadding = 0;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                if (newline) Console.WriteLine(text);
                else Console.Write(text);
            }

            while (removeMenuOn)
            {
                Console.Clear();

                WriteCentered("--- Remove Farmers ---");
                WriteCentered("");

                var farmers = Menu.FarmersList();
                if (farmers.Count == 0)
                {
                    WriteCentered("No farmers to remove.");
                }
                else
                {
                    for (int i = 0; i < farmers.Count; i++)
                    {
                        WriteCentered($"{i + 1} - {farmers[i].GetUsername()}");
                    }
                }

                WriteCentered("");
                WriteCentered("0 - Go Back");
                WriteCentered("");
                WriteCentered("Which Farmer do you want to remove? (Input 0 to go back): ", false);

                ControlMenu();
            }

            void ControlMenu()
            {
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    // Invalid input, ignore and return to menu loop
                    return;
                }

                var farmers = Menu.FarmersList();

                if (input == 0)
                {
                    removeMenuOn = false;
                    Console.Clear();
                    Menu.DisplayMenu();
                }
                else if (input > 0 && input <= farmers.Count)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteCentered($"{farmers[input - 1].GetUsername()} has been removed.\n");
                    Console.ResetColor();
                    farmers.RemoveAt(input - 1);
                    // Wait a bit so user can read the message
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    // Invalid number, ignore and continue
                }
            }
        }
    }
}
