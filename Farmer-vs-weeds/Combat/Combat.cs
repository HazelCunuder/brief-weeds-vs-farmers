using Farmer_vs_weeds.Menu;

namespace Farmer_vs_weeds.Combat
{
    public static class Combat
    {
        public static void Fight(List<Farmer> opponent)
        {
            bool isFightOngoing = true;
            int currentTurn = 1;

            Farmer player = Tournament.FarmerPlayer;

            // Centered text helper
            void WriteCentered(string text, bool newline = true)
            {
                int leftPadding = (Console.WindowWidth - text.Length) / 2;
                if (leftPadding < 0) leftPadding = 0;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                if (newline) Console.WriteLine(text);
                else Console.Write(text);
            }

            if (player == null)
            {
                WriteCentered("No player selected.");
                Console.ReadKey();
                return;
            }

            Farmer enemy = opponent[0]; // First opponent

            while (isFightOngoing)
            {
                Console.Clear();
                WriteCentered($"--- Turn {currentTurn} ---");
                WriteCentered("");

                WriteCentered($"Your Farmer: {player.GetUsername()}");
                WriteCentered($"Current HP: {player.GetHPs()}");
                WriteCentered("");

                // Player attacks
                WriteCentered(">>> Player Attacks <<<");
                enemy.TakeDamage(player.Attack());
                WriteCentered("");
                enemy.ShowInfos();
                WriteCentered("");

                if (enemy.GetHPs() <= 0)
                {
                    WriteCentered($"{player.GetUsername()} has won the fight!");
                    Console.ReadKey();
                    isFightOngoing = false;
                    break;
                }

                // Enemy attacks
                WriteCentered(">>> Enemy Attacks <<<");
                player.TakeDamage(enemy.Attack());
                WriteCentered("");
                player.ShowInfos();
                WriteCentered("");

                if (player.GetHPs() <= 0)
                {
                    WriteCentered($"{enemy.GetUsername()} has won the fight!");
                    Console.ReadKey();
                    isFightOngoing = false;
                    break;
                }

                currentTurn++;
                Console.ReadKey(); // Optional delay for readability
            }

            WriteCentered("");
            WriteCentered("Press any key to return to the menu...");
            Console.ReadKey();
            Menu.Menu.DisplayMenu();
        }
    }
}