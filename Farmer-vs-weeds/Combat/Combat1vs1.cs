using Farmer_vs_weeds.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Combat
{
    internal class Combat1vs1
    {
        public static void FightOneVsOne()
        {
            bool isFightOngoing = true;
            int currentTurn = 1;

            // Recover the player via the Tournament class
            Farmer player1 = Tournament.FarmerPlayer;
            Farmer player2 = Tournament.FarmerPlayer;

            if (player1 == null ||player2 == null)
            {
                Console.WriteLine("\nBoth players must be selected.\n" +
                    "\nPlease create 2 characters for a 1 vs 1 fight\n" +
                    "\npress any key to return to the menu\n");

                Console.ReadKey();
                Console.Clear();
                Menu.Menu.DisplayMenu();
                return;
            }

            while (isFightOngoing)
            {
                Console.WriteLine($"\n--- Turn {currentTurn} ---\n");

                // Player attacks enemy
                Console.WriteLine($"\n{player1.GetUsername()} attacks!\n");
                player2.TakeDamage(player1.Attack());
                player2.ShowInfos();

                if (player2.GetHPs() <= 0)
                {
                    Console.WriteLine($"\n{player1.GetUsername()} has won the fight!");
                    isFightOngoing = false;
                    break;
                }

                // Enemy attacks player
                Console.WriteLine($"\n{player2.GetUsername()} attacks!\n");
                player1.TakeDamage(player2.Attack());
                player1.ShowInfos();

                if (player1.GetHPs() <= 0)
                {
                    Console.WriteLine($"\n{player2.GetUsername()} has won the fight!");
                    isFightOngoing = false;
                    break;
                }

                currentTurn++;
            }

            Console.ReadKey();
            Menu.Menu.DisplayMenu();
        }
    }
}
