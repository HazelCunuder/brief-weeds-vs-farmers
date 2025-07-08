using System;
using System.Collections.Generic;

namespace Farmer_vs_weeds.Combat
{
    internal class ChoiceFarmer
    {
        // -- Create Properties Player 1 and 2 to reuse in Combat and Combat 1v1 --
        public static Farmer Player1;
        public static Farmer Player2;

        public static void SelectFarmer()
        {
            List<Farmer> allFarmers = Menu.Menu.FarmersList();
            Console.Clear();

            // -- Internal Function to center the text in Console --
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

            // -- Check to see if we have at least 2 farmers created in order to start a 1on1 fight --
            if (allFarmers.Count < 2)
            {
                WriteCentered("\nYou need at least 2 farmers to start a 1 vs 1 fight.\n");
                WriteCentered("\nPress any key to return to the menu...");
                Console.ReadKey();
                Menu.Menu.DisplayMenu();
                return;
            }

            WriteCentered("List of available farmers:");
            WriteCentered("");

            // -- Display the List of all the available combatants --
            for (int i = 0; i < allFarmers.Count; i++)
            {
                Farmer farmer = allFarmers[i];
                WriteCentered($"{i + 1} - {farmer.GetUsername()} , Type: {farmer.GetTypes()}, HP: {farmer.GetHPs()}, Attack Dice: {farmer.GetAttackDices()}");
            }

            int player1Index = -1;
            int player2Index = -1;

            // --- Player 1 Selection ---
            while (true)
            {
                WriteCentered("\nPlayer 1, choose your Farmer: ");
                    player1Index = Convert.ToInt32(Console.ReadLine());
                if (player1Index < 1 || player1Index > allFarmers.Count)
                {
                    WriteCentered("Invalide choice.");
                }
                else
                {
                    player1Index -= 1; // Adjust for 0-based index
                    break;
                }
                WriteCentered("Invalid choice. Try again.");
            }

            // -- Player 2 Selection --

            while (player2Index < 0 || player2Index >= allFarmers.Count || player2Index == player1Index)
            {
                WriteCentered("\nPlayer 2, choose your Farmer: ");
                player2Index = Convert.ToInt32(Console.ReadLine());
                if (player2Index < 1 || player2Index > allFarmers.Count || player2Index == player1Index)
                {
                    WriteCentered("Invalid choice.");
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
            WriteCentered($"\n{ChoiceFarmer.Player1.GetUsername()} VS {ChoiceFarmer.Player2.GetUsername()} — Let the battle begin!\n");

            Combat1vs1.FightOneVsOne();
        }
    }
}
