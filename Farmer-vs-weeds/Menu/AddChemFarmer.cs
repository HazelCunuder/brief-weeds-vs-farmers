using System;
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
            string types = "Chem Farmer";

            bool validHp = false;
            bool validAttackDices = false;

            Console.Clear();

            // -- Centers Text in Console --
            void WriteCentered(string text, bool newline = true)
            {
                int leftPadding = (Console.WindowWidth - text.Length) / 2;
                if (leftPadding < 0)
                    leftPadding = 0;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                if (newline)
                    Console.WriteLine(text);
                else
                    Console.Write(text);
            }

            // -- Name Input --
            WriteCentered(" ");
            WriteCentered("=== Create Chem Farmer ===");
            WriteCentered(" ");
            WriteCentered("Name: ", false);
            username = Console.ReadLine();

            // -- HP Input --
            while (!validHp)
            {
                Console.Clear();
                WriteCentered($"Hello {username}, let's set up your stats.");
                WriteCentered(" ");
                WriteCentered("Choose HP between 40 and 90:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int inputUser) && inputUser >= 40 && inputUser <= 90)
                {
                    hp = inputUser;
                    validHp = true;
                }
                else
                {
                    WriteCentered("Error: Follow the instructions.");
                    Thread.Sleep(1000);
                }
            }

            // -- Attack Dice Input --
            while (!validAttackDices)
            {
                Console.Clear();
                WriteCentered("Choose number of attack dice (6 to 9 d6):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int inputUser) && inputUser >= 6 && inputUser <= 9)
                {
                    attackDices = inputUser;
                    validAttackDices = true;
                }
                else
                {
                    WriteCentered("Error: Follow the instructions.");
                    Thread.Sleep(1000);
                }
            }

            // -- Add to List --
            Menu.FarmersList().Add(new ChemFarmer(username, hp, attackDices, types));

            // -- Final Display --
            Console.Clear();
            WriteCentered(" ");
            WriteCentered($"{types} \"{username}\" created!");
            WriteCentered($"HP: {hp} | Dice: {attackDices}d6");
            WriteCentered(" ");
            WriteCentered("Press any key to go back...");
            Console.ReadKey();
        }
    }
}
