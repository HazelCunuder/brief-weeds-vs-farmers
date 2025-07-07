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

        public static void SelectFarmer()
        {          
            int player1Index = -1;
            int player2Index = -1;

            List<Farmer> allFarmers = Menu.Menu.FarmersList();

            Console.WriteLine("\n--- 1 vs 1 Fight ---\n");

            if (allFarmers.Count < 2)
            {
                Console.WriteLine("\nYou need at least 2 farmers to start a 1 vs 1 fight.\n");
                Console.WriteLine("\nPress any key to return to the menu...");
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
                Console.WriteLine("\nPlayer 1, choise your Farmer :");
                    player1Index = Convert.ToInt32(Console.ReadLine());
                if (player1Index < 1 || player1Index > allFarmers.Count)
                {
                    Console.WriteLine("Invalide choice.");
                }
                else
                {
                    player1Index -= 1;
                }
            }

            // Player two choice

            while (player2Index < 0 || player2Index >= allFarmers.Count || player2Index == player1Index)
            {
                Console.WriteLine("\nPlayer 2, choise your Farmer :");
                player2Index = Convert.ToInt32(Console.ReadLine());
                if (player2Index < 1 || player2Index > allFarmers.Count || player2Index == player1Index)
                {
                    Console.WriteLine("Invalide choice.");
                }
                else
                {
                    player2Index -= 1;
                }
            }

            ChoiceFarmer.Player1 = allFarmers[player1Index];
            ChoiceFarmer.Player2 = allFarmers[player2Index];

            Console.Clear();
            Console.WriteLine($"\n{ChoiceFarmer.Player1.GetUsername()} VS {ChoiceFarmer.Player2.GetUsername()} — Let the battle begin!\n");

            Combat1vs1.FightOneVsOne();


        }
    }
}
