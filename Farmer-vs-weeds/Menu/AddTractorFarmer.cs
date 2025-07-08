using Farmer_vs_weeds.Farmers;
using Farmer_vs_weeds.Menu;

internal class AddTractorFarmer
{
    public static void TractorFarmer()
    {
        string username;
        int hp = 0;
        int attackDices = 0;
        string types = "Tractor Farmer";
        bool inTractor = true;

        bool validHp = false;
        bool validAttackDices = false;

        Console.Clear();

        // -- Centers Text in Console --
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

        // -- Name input --
        WriteCentered(" ");
        WriteCentered("=== Create Tractor Farmer ===");
        WriteCentered(" ");
        WriteCentered("Name: ", false);
        username = Console.ReadLine();

        // -- HP input loop --
        while (!validHp)
        {
            Console.Clear();
            WriteCentered($"Welcome {username}!");
            WriteCentered(" ");
            WriteCentered("Choose HP between 100 and 150:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int inputUser) && inputUser >= 100 && inputUser <= 150)
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

        // -- Attack Dice input loop --
        while (!validAttackDices)
        {
            Console.Clear();
            WriteCentered("Choose number of attack dice (1 to 3 d6):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int inputUser) && inputUser >= 1 && inputUser <= 3)
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

        // -- Add Farmer --
        Menu.FarmersList().Add(new TractorFarmer(username, hp, attackDices, inTractor, types));

        // -- Final Message --
        Console.Clear();
        WriteCentered(" ");
        WriteCentered($"{types} \"{username}\" created!");
        WriteCentered($"HP: {hp} | Dice: {attackDices}d6");
        WriteCentered(" ");
        WriteCentered("Press any key to return...");
        Console.ReadKey();
    }
}
