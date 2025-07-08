using System;
using System.Collections.Generic;
using System.Linq;
using Farmer_vs_weeds.Farmers;
using Farmer_vs_weeds.Combat;

namespace Farmer_vs_weeds.Menu
{
    public class Tournament
    {
        public static Farmer FarmerPlayer { get; set; }

        public Farmer GetPlayer()
        {
            return FarmerPlayer;
        }

        public static void TournamentMenu()
        {
            int PlayerChoice;
            int FarmerRandom = 0;
            bool ChoiceListInvalid = true;
            bool ChoiceRandomInvalid = true;

            // Helper to center text
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

            Console.Clear();
            WriteCentered("--- Tournament Start ---");

            List<Farmer> Farmers = Menu.FarmersList();

            if (Farmers.Count < 1)
            {
                WriteCentered("");
                WriteCentered("You need at least one created farmer to start a tournament");
                WriteCentered("");
                WriteCentered("Press any key to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
                Menu.DisplayMenu();
                return;
            }

            WriteCentered("");
            WriteCentered("List of your farmers:");
            WriteCentered("");

            for (int i = 0; i < Farmers.Count; i++)
            {
                Farmer f = Farmers[i];
                WriteCentered(
                    $"{i + 1} - {f.GetUsername()} | Type: {f.GetTypes()} | HP: {f.GetHPs()} | Dice: {f.GetAttackDices()}"
                );
            }

            // Player selects farmer
            while (ChoiceListInvalid)
            {
                WriteCentered("");
                WriteCentered("Choose your farmer by number: ", false);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                if (
                    int.TryParse(Console.ReadLine(), out PlayerChoice)
                    && PlayerChoice >= 1
                    && PlayerChoice <= Farmers.Count
                )
                {
                    WriteCentered($"You selected: {Farmers[PlayerChoice - 1].GetUsername()}");
                    FarmerPlayer = Farmers[PlayerChoice - 1];
                    ChoiceListInvalid = false;
                }
                else
                {
                    WriteCentered("Invalid choice. Try again.");
                }
            }

            // Choose number of opponents
            while (ChoiceRandomInvalid)
            {
                WriteCentered("");
                WriteCentered("Enter total number of participants (2 to 12): ", false);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                if (
                    int.TryParse(Console.ReadLine(), out FarmerRandom)
                    && FarmerRandom >= 2
                    && FarmerRandom <= 12
                )
                {
                    WriteCentered($"Total participants selected: {FarmerRandom}");
                    ChoiceRandomInvalid = false;
                }
                else
                {
                    WriteCentered("Invalid number. Try again.");
                }
            }

            // Generate opponents
            List<Farmer> opponent = new List<Farmer>();
            for (int i = 0; i < FarmerRandom; i++)
            {
                opponent.Add(FarmerRandomTournament.GenerateFarmer());
            }

            // Display opponents
            Console.Clear();
            WriteCentered("--- Opponents Generated ---");
            WriteCentered("");
	    
            for (int i = 0; i < opponent.Count; i++)
            {
                Farmer r = opponent[i];
                WriteCentered(
                    $"{i + 1} - {r.GetUsername()} | Type: {r.GetTypes()} | HP: {r.GetHPs()} | Dice: {r.GetAttackDices()}"
                );
            }
	    
            WriteCentered("");
            WriteCentered(
                $"Tournament begins with your farmer and {FarmerRandom} random opponents."
            );
            Combat.Combat.Fight(opponent);
            WriteCentered("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
