using System;
using System.Collections.Generic;

namespace Farmer_vs_weeds.Combat
{
    internal class ChoiceFarmer
    {
        public static Farmer Player1;
        public static Farmer Player2;

        // Centered text helper
        static void WriteCentered(string text, bool newline = true)
        {
            int leftPadding = (Console.WindowWidth - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            if (newline) Console.WriteLine(text);
            else Console.Write(text);
        }
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
                Console.WriteLine("\nYou need at least 2 farmers to start a 1 vs 1 fight.\n");
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Menu.Menu.DisplayMenu();
                return;
            }

            WriteCentered("List of available farmers:");
            WriteCentered("");

            for (int i = 0; i < allFarmers.Count; i++)
            {
                Farmer farmer = allFarmers[i];
                Console.WriteLine($"{i + 1} - {farmer.GetUsername()} , Type: {farmer.GetTypes()}, HP: {farmer.GetHPs()}, Attack Dice: {farmer.GetAttackDices()}");
            }

            int player1Index = -1;
            int player2Index = -1;

            // --- Player 1 Selection ---
            while (true)
            {
                Console.WriteLine("\nPlayer 1, choose your Farmer: ");
                    player1Index = Convert.ToInt32(Console.ReadLine());
                if (player1Index < 1 || player1Index > allFarmers.Count)
                {
                    Console.WriteLine("Invalide choice.");
                }
                else
                {
                    player1Index -= 1; // Adjust for 0-based index
                    break;
                }
                WriteCentered("Invalid choice. Try again.");
            }

            // Player two choice

            while (player2Index < 0 || player2Index >= allFarmers.Count || player2Index == player1Index)
            {
                Console.WriteLine("\nPlayer 2, choose your Farmer: ");
                player2Index = Convert.ToInt32(Console.ReadLine());
                if (player2Index < 1 || player2Index > allFarmers.Count || player2Index == player1Index)
                {
                    Console.WriteLine("Invalid choice.");
                }
                else
                {
                    player2Index -= 1;
                    break;
                }
                WriteCentered("Invalid choice or same as Player 1. Try again.");
            }

            Player1 = allFarmers[player1Index];
            Player2 = allFarmers[player2Index];

            Console.Clear();
            Console.WriteLine($"\n{ChoiceFarmer.Player1.GetUsername()} VS {ChoiceFarmer.Player2.GetUsername()} — Let the battle begin!\n");

            Combat1vs1.FightOneVsOne();
        }
    }
}
