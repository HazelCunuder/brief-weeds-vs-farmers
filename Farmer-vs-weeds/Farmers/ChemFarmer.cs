using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Farmers
{
    internal class ChemFarmer : Farmer
    {
        // -- Constructor Statement --

        public ChemFarmer(string username, int healthPoints, int attackDices, string types)
            : base(username, healthPoints, attackDices, types)
        {
            bool correctChemFarmerHP = false;

            while (!correctChemFarmerHP)
            {
                if (healthPoints < 0)
                {
                    Console.WriteLine("You cannot create a farmer with negative health\n");
                    Console.Write("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (healthPoints < 40)
                {
                    Console.WriteLine("You cannot create a Chem Farmer with less than 40HP\n");
                    Console.Write("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (healthPoints > 90)
                {
                    Console.WriteLine("You cannot create a Chem Farmer with more than 90HP\n");
                    Console.Write("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else
                {
                    SetHealthPoints(healthPoints);
                    correctChemFarmerHP = true;
                }
            }
        }

        // -- Methods --
        public override int SpecialAttack()
        {
            Random dice = new Random();
            int rollTotal = 0;
            int attackDice = dice.Next(3, 9);

            for (int i = 0; i < GetAttackDices(); i++)
            {
                rollTotal += attackDice;
            }

            Console.WriteLine($"Special Attack ! roll : {rollTotal}");
            return rollTotal;
        }
        public override int Attack()
        {
            Random dice = new Random();
            int rollTotal = 0;
            int attackDice = dice.Next(1, 6);

            for (int i = 0; i < GetAttackDices(); i++)
            {
                rollTotal += attackDice;
            }

            return rollTotal;
        }
    }
}
