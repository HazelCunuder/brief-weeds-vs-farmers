using Farmer_vs_weeds.Menu;

namespace Farmer_vs_weeds.Combat
{
    public static class Combat
    {
        // --- Methods ---
        public static void Fight(List<Farmer> opponent)
        {
            bool isFightOngoing = true;
            int currentTurn = 1;

            // Recover the player via the Tournament class
            Farmer player = Tournament.FarmerPlayer;

            if (player == null)
            {
                Console.WriteLine("No players selected.");
                return;
            }

            Farmer enemy = opponent[0]; // opponent[0] pour prendre le 1er adversaire dans la liste

            while (isFightOngoing)
            {
                Console.WriteLine($"\n--- Turn {currentTurn} ---\n");
                Console.WriteLine($"Our Fighter: {player.GetUsername()}");
                Console.WriteLine($"Current HP: {player.GetHPs()}");

                // Player attacks enemy
                Console.WriteLine("\nPlayer Attack\n");
                enemy.TakeDamage(player.Attack());
                enemy.ShowInfos();

                if (enemy.GetHPs() <= 0)
                {
                    Console.WriteLine($"\n{player.GetUsername()} has won the fight!");
                    isFightOngoing = false;
                    break;
                }

                // Enemy attacks player
                Console.WriteLine("\nEnnemy Attack\n");
                player.TakeDamage(enemy.Attack());
                player.ShowInfos();

                if (player.GetHPs() <= 0)
                {
                    Console.WriteLine($"\n{enemy.GetUsername()} has won the fight!");
                    isFightOngoing = false;
                    break;
                }

                currentTurn++;
            }

            Console.ReadKey();
        }
    }
}
