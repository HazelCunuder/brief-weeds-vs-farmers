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

            // -- Internal Function to center the text in Console --
            void WriteCentered(string text, bool newline = true)
            {
                int leftPadding = (Console.WindowWidth - text.Length) / 2;
                if (leftPadding < 0) leftPadding = 0;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                if (newline) Console.WriteLine(text);
                else Console.Write(text);
            }

            // -- Check if player has been selected --
            if (player == null)
            {
                WriteCentered("No player selected.");
                Console.ReadKey();
                return;
            }

            // -- Take the first opponent in the list and set it as our current enemy --
            Farmer enemy = opponent[0];

            while (isFightOngoing)
            {
                Console.Clear();
                WriteCentered($"--- Turn {currentTurn} ---");
                WriteCentered("");

                WriteCentered($"Your Farmer: {player.GetUsername()}");
                WriteCentered($"Current HP: {player.GetHPs()}");
                WriteCentered("");

                // -- Player Attacks --
                WriteCentered(">>> Player Attacks <<<");
                enemy.TakeDamage(player.Attack());
                WriteCentered("");
                enemy.ShowInfos();
                WriteCentered("");

                // -- If enemy's health is under or equal to 0, display the winning message --
                if (enemy.GetHPs() <= 0)
                {
                    WriteCentered($"{player.GetUsername()} has won the fight!");
                    Console.ReadKey();
                    isFightOngoing = false;
                    break;
                }

                // -- Enemy attacks --
                WriteCentered(">>> Enemy Attacks <<<");
                player.TakeDamage(enemy.Attack());
                WriteCentered("");
                player.ShowInfos();
                WriteCentered("");

                // -- If our health is under or equal to 0, display the losing message --
                if (player.GetHPs() <= 0)
                {
                    WriteCentered($"{enemy.GetUsername()} has won the fight!");
                    Console.ReadKey();
                    isFightOngoing = false;
                    break;
                }

                currentTurn++;
                Console.ReadKey(); 
            }

            WriteCentered("");
            WriteCentered("Press any key to return to the menu...");
            Console.ReadKey();
            Menu.Menu.DisplayMenu();
        }
    }
}