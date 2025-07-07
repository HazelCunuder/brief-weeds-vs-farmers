namespace Farmer_vs_weeds.Combat
{
    internal class Combat1vs1
    {
        public static void FightOneVsOne()
        {
            bool isFightOngoing = true;
            int currentTurn = 1;

            Farmer player1 = ChoiceFarmer.Player1;
            Farmer player2 = ChoiceFarmer.Player2;

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

            while (isFightOngoing)
            {
                Console.Clear();
                WriteCentered($"--- Turn {currentTurn} ---");
                WriteCentered("");

                // Player 1 attacks
                WriteCentered($"{player1.GetUsername()} attacks!");
                player2.TakeDamage(player1.Attack());
                WriteCentered("");
                player2.ShowInfos();

                if (player2.GetHPs() <= 0)
                {
                    WriteCentered("");
                    WriteCentered($"{player1.GetUsername()} has won the fight!");
                    Console.ReadKey();
                    break;
                }

                // Player 2 attacks
                WriteCentered("");
                WriteCentered($"{player2.GetUsername()} attacks!");
                player1.TakeDamage(player2.Attack());
                WriteCentered("");
                player1.ShowInfos();

                if (player1.GetHPs() <= 0)
                {
                    WriteCentered("");
                    WriteCentered($"{player2.GetUsername()} has won the fight!");
                    Console.ReadKey();
                    break;
                }

                currentTurn++;
                Console.ReadKey();
            }

            WriteCentered("");
            WriteCentered("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            Menu.Menu.DisplayMenu();
        }
    }
}
