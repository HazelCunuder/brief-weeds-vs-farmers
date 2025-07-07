using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmer_vs_weeds.Menu;
using Farmer_vs_weeds.Combat;

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
            int player1Index = -1;
            int player2Index = -1;

            List<Farmer> allFarmers = Menu.Menu.FarmersList();

            WriteCentered("\n--- 1 vs 1 Fight ---\n");

            if (allFarmers.Count < 2)
            {
                WriteCentered("\nYou need at least 2 farmers to start a 1 vs 1 fight.\n");
                WriteCentered("\nPress any key to return to the menu...");
                Console.ReadKey();
                Menu.Menu.DisplayMenu();
                return;
            }

            Console.WriteLine("\n--- List of farmers available ---\n");

            for (int i = 0; i < allFarmers.Count; i++)
            {
                Farmer farmer = allFarmers[i];
                Console.WriteLine($"{i + 1} - {farmer.GetUsername()} , Type: {farmer.GetTypes()}, HP: {farmer.GetHPs()}, Attack Dice: {farmer.GetAttackDices()}");
            }

            // Player one choice
            while(player1Index < 0 || player1Index >= allFarmers.Count)
            {
                WriteCentered("\nPlayer 1, choose your Farmer: ");
                    player1Index = Convert.ToInt32(Console.ReadLine());
                if (player1Index < 1 || player1Index > allFarmers.Count)
                {
                    WriteCentered("Invalide choice.");
                }
                else
                {
                    player1Index -= 1;
                }
            }

            // Player two choice

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
                }
            }

            ChoiceFarmer.Player1 = allFarmers[player1Index];
            ChoiceFarmer.Player2 = allFarmers[player2Index];

            Console.Clear();
            WriteCentered($"\n{ChoiceFarmer.Player1.GetUsername()} VS {ChoiceFarmer.Player2.GetUsername()} — Let the battle begin!\n");

            Combat1vs1.FightOneVsOne();


        }
    }
}
