using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmer_vs_weeds.Menu;

namespace Farmer_vs_weeds.Menu
{
    internal class FarmerRandomTournament
    {
        private static Random Farmer = new Random();
        private static List<string> FarmerName = new List<string>
        {
            "Loïc",
            "Alexandre",
            "Julien",
            "Abdellah",
            "Nicolas",
            "Maxime",
            "Cédric",
            "Vincent",
            "Donovan",
            "Othman",
            "Amine",
            "Benjamin",
        };

        // --- Methods ---
        public static Farmer GenerateFarmer()
        {
            int index = Farmer.Next(FarmerName.Count);
            string name = FarmerName[index];
            FarmerName.RemoveAt(index);

            string types = "";
            int farmer = Farmer.Next(3);
            int hp = 0;
            int attackDices = 0;

            // -- Generate random opponents --
            switch (farmer)
            {
                case 0:
                    types = "Classic Farmer";
                    hp = Farmer.Next(70, 121);
                    attackDices = Farmer.Next(4, 7);
                    break;

                case 1:
                    types = "Chem Farmer";
                    hp = Farmer.Next(40, 91);
                    attackDices = Farmer.Next(6, 10);
                    break;

                case 2:
                    types = "Tractor Farmer";
                    hp = Farmer.Next(100, 151);
                    attackDices = Farmer.Next(1, 4);
                    break;
            }

            return new Farmer(name, hp, attackDices, types);
        }
    }
}
