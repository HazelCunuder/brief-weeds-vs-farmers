namespace Farmer_vs_weeds.Combat
{
    internal class Combat1vs1
    {

        // Centered text helper
        static void WriteCentered(string text, bool newline = true)
        {
            int leftPadding = (Console.WindowWidth - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            if (newline) Console.WriteLine(text);
            else Console.Write(text);
        }
        public static void FightOneVsOne()
        {
            bool isFightOngoing = true;
            int currentTurn = 1;
          
            int userInput1;
            int damage1;
            int userInput2;
            int damage2;

            // Cooldown counter
            int cooldownSpecialAttackP1 = 0;
            int cooldownSpecialAttackP2 = 0;

            // Recover the player via the Tournament class
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

                // --- Player one attack --- 
                WriteCentered($"\n-- {player1.GetUsername()}, choose your attack --\n");
                WriteCentered("1 - Normal Attack");

                // Checks if the special attack is available
                if (cooldownSpecialAttackP1 == 0)
                {
                    WriteCentered("2 - Special Attack (Available)\n");
                }
                else
                {
                    WriteCentered($"2 - Special Attack (Cooldown: {cooldownSpecialAttackP1} turns left)\n");
                }

                // Recovers player 1's choice
                userInput1 = Convert.ToInt32(Console.ReadLine());          

                if (userInput1 == 2 && cooldownSpecialAttackP1 == 0)
                {
                    damage1 = player1.SpecialAttack();
                    cooldownSpecialAttackP1 = 2;
                }
                else
                {
                    damage1 = player1.Attack();
                }

                player2.TakeDamage(damage1);
                player2.ShowInfos();

                if (player2.GetHPs() <= 0)
                {
                    Console.WriteLine($"\n{player1.GetUsername()} has won the fight!");
                    break;
                }

                // --- Player two attack ---
                WriteCentered($"\n-- {player2.GetUsername()}, choose your attack --\n");
                WriteCentered("1 - Normal Attack");

                // Checks if the special attack is available
                if (cooldownSpecialAttackP2 == 0)
                {
                    WriteCentered("2 - Special Attack (Available)\n");
                }
                else
                {
                    WriteCentered($"2 - Special Attack (Cooldown: {cooldownSpecialAttackP2} turns left)\n");
                }

                // Recovers player 2's choice
                userInput2 = Convert.ToInt32(Console.ReadLine());

                if (userInput2 == 2 && cooldownSpecialAttackP2 == 0)
                {
                    damage2 = player2.SpecialAttack();
                    cooldownSpecialAttackP1 = 2;
                }
                else
                {
                    damage2 = player2.Attack();
                }

                player2.TakeDamage(damage2);
                player2.ShowInfos();

                if (player1.GetHPs() <= 0)
                {
                    Console.WriteLine($"\n{player2.GetUsername()} has won the fight!");
                    break;
                }

                // Cooldown reduction at end of turn
                if (cooldownSpecialAttackP1 > 0) cooldownSpecialAttackP1--;
                if (cooldownSpecialAttackP2 > 0) cooldownSpecialAttackP2--;

                
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
