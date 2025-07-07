using System;
using System.Collections.Generic;

namespace Farmer_vs_weeds.Combat
{
    internal class ChoiceFarmer
    {
        public static Farmer Player1;
        public static Farmer Player2;

        public static void SelectFarmer()
        {
            List<Farmer> allFarmers = Menu.Menu.FarmersList();
            Console.Clear();

            void WriteCentered(string text, bool newline = true)
            {
                int leftPadding = (Console.WindowWidth - text.Length) / 2;
                if (leftPadding < 0) leftPadding = 0;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                if (newline) Console.WriteLine(text);
                else Console.Write(text);
            }

            WriteCentered("--- 1 vs 1 Fight ---");
            WriteCentered("");

            if (allFarmers.Count < 2)
            {
                WriteCentered("You need at least 2 farmers to start a 1 vs 1 fight.");
                WriteCentered("");
                WriteCentered("Press any key to return to the menu...");
                Console.ReadKey();
                Menu.Menu.DisplayMenu();
                return;
            }

            WriteCentered("List of available farmers:");
            WriteCentered("");

            for (int i = 0; i < allFarmers.Count; i++)
            {
                Farmer f = allFarmers[i];
                WriteCentered($"{i + 1} - {f.GetUsername()}, Type: {f.GetTypes()}, HP: {f.GetHPs()}, Attack Dice: {f.GetAttackDices()}");
            }

            int player1Index = -1;
            int player2Index = -1;

            // --- Player 1 Selection ---
            while (true)
            {
                WriteCentered("");
                WriteCentered("Player 1, choose your Farmer (number): ", false);
                if (int.TryParse(Console.ReadLine(), out player1Index) &&
                    player1Index >= 1 && player1Index <= allFarmers.Count)
                {
                    player1Index -= 1; // Adjust for 0-based index
                    break;
                }
                WriteCentered("Invalid choice. Try again.");
            }

            // --- Player 2 Selection ---
            while (true)
            {
                WriteCentered("");
                WriteCentered("Player 2, choose your Farmer (number): ", false);
                if (int.TryParse(Console.ReadLine(), out player2Index) &&
                    player2Index >= 1 && player2Index <= allFarmers.Count &&
                    player2Index - 1 != player1Index)
                {
                    player2Index -= 1;
                    break;
                }
                WriteCentered("Invalid choice or same as Player 1. Try again.");
            }

            Player1 = allFarmers[player1Index];
            Player2 = allFarmers[player2Index];

            Console.Clear();
            WriteCentered($"{Player1.GetUsername()} VS {Player2.GetUsername()} — Let the battle begin!");
            Thread.Sleep(1500);

            Combat1vs1.FightOneVsOne();
        }
    }
}
