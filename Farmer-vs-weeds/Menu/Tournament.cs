using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Farmer_vs_weeds.Combat;

namespace Farmer_vs_weeds.Menu
{
    public class Tournament
    {
       // -- Properties Statements -- 
        public static Farmer FarmerPlayer{ get; set; }

        // --- Methods ---
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


            Console.Clear();
            Console.WriteLine("--- Tournament Start---");

            List<Farmer> Farmers = Menu.FarmersList();

            int totalFarmers = 0;

            foreach(Farmer total in Farmers)
            {
                totalFarmers++;
            }

            if (totalFarmers < 1)
            {
                Console.Write("\nYou need at least 1 farmers create to start a tournament\n");
                Console.WriteLine("\nPress any key to return menu");
                Console.ReadKey();
                Console.Clear();
                Menu.DisplayMenu();
            }

            // Choice in List of Farmer created bye the User
            Console.WriteLine("\nList of your farmers :\n");
            for (int i = 0; i < Farmers.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Farmers[i].GetUsername()} Type {Farmers[i].GetTypes()} HP {Farmers[i].GetHPs()} Attack Dice {Farmers[i].GetAttackDices()}\n");
            };

            //Player Choose a farmer from the list
            while (ChoiceListInvalid)
                {
                    Console.WriteLine("\n--- Choose your Farmer with number  ---\n");
                    PlayerChoice = Convert.ToInt32(Console.ReadLine());
            
                if (PlayerChoice < 1 || PlayerChoice > Farmers.Count)
                {
                    Console.WriteLine("\nError , Invalid choice");
                }
                else
                {
                    Console.WriteLine("\nYou have selected farmer number : " + PlayerChoice);
                    FarmerPlayer = Farmers[PlayerChoice - 1];
                    ChoiceListInvalid = false;
                }              
            }

            // Choice for number of random Farmers participating in the tournament
            while (ChoiceRandomInvalid)
            {
                Console.WriteLine("\n--- Enter total number of participants (2 to 12) ---\n");
                    FarmerRandom = Convert.ToInt32(Console.ReadLine());

                if (FarmerRandom < 2 || FarmerRandom > 12)
                {
                    Console.WriteLine("\nError , Invalid choice");
                }
                else
                {
                    Console.WriteLine("\nYou have selected farmer number : " + FarmerRandom);
                    ChoiceRandomInvalid = false;
                }


            }

            // Generate random opponents for the tournament
            List<Farmer> opponent = new List<Farmer>();

            for(int i = 0; i  < FarmerRandom; i++)
            {
                opponent.Add(FarmerRandomTournament.GenerateFarmer());
            }

            Console.Clear();
            // Show opponent generated
            Console.WriteLine("\n--- Opponents generated ---\n");
            for (int i = 0; i < opponent.Count; i++)
            {
                Farmer R = opponent[i];
                Console.WriteLine($"{i + 1}  {R.GetUsername()}, types: {R.GetTypes()}, HP: {R.GetHPs()}, Attack Dice: {R.GetAttackDices()}");
            }

            Console.WriteLine($"\nTournament begins with your farmer and {FarmerRandom} random opponents.\n");
            Combat.Combat.Fight(opponent);

        } 
    }
}
