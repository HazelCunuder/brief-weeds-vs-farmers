using Farmer_vs_weeds;
using Farmer_vs_weeds.Menu;

internal class AddSimpleFarmer
{
    public static void SimpleFarmer()
    {
        string username;
        int hp = 0;
        int attackDices = 0;
        string types = "Classic Farmer";

        bool validHp = false;
        bool validAttackDices = false;

        Console.Clear();

        // Helper method for centering text
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

        // Name input
        WriteCentered(" ");
        WriteCentered("=== Create Classic Farmer ===");
        WriteCentered(" ");
        WriteCentered("Name: ", false);
        username = Console.ReadLine();

        // HP input loop
        while (!validHp)
        {
            Console.Clear();
            WriteCentered($"Hello {username}, let’s configure your stats");
            WriteCentered(" ");
            WriteCentered("Choose HP between 70 and 120:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int inputUser) && inputUser >= 70 && inputUser <= 120)
            {
                hp = inputUser;
                validHp = true;
            }
            else
            {
                WriteCentered("Error: Follow the instructions.");
                Thread.Sleep(1000);
            }
        }

        // Attack dice input loop
        while (!validAttackDices)
        {
            Console.Clear();
            WriteCentered("Choose number of attack dice (4 to 6 d6):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int inputUser) && inputUser >= 4 && inputUser <= 6)
            {
                attackDices = inputUser;
                validAttackDices = true;
            }
            else
            {
                WriteCentered("Error: Follow the instructions.");
                Thread.Sleep(1000);
            }
        }

        Menu.FarmersList().Add(new Farmer(username, hp, attackDices, types));

        Console.Clear();
        WriteCentered(" ");
        WriteCentered($" {types} \"{username}\" created!");
        WriteCentered($"HP: {hp} | Dice: {attackDices}d6");
        WriteCentered(" ");
        WriteCentered("Press any key to go back...");
        Console.ReadKey();
    }
}
