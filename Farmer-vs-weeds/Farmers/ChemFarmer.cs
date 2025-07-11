﻿using System;
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

                // -- Verify user's health input --
                if (healthPoints < 0)
                {
                    WriteCentered("You cannot create a farmer with negative health\n");
                    WriteCentered("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (healthPoints < 40)
                {
                    WriteCentered("You cannot create a Chem Farmer with less than 40HP\n");
                    WriteCentered("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (healthPoints > 90)
                {
                    WriteCentered("You cannot create a Chem Farmer with more than 90HP\n");
                    WriteCentered("Please write a correct HP value: ");
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

        // -- Centers Text in Console --
        static void WriteCentered(string text, bool newline = true)
        {
            int leftPadding = (Console.WindowWidth - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            if (newline) Console.WriteLine(text);
            else Console.Write(text);
        } 

        // -- Allows Chem Farmer to do more damage before having a cooldown --
        public override int SpecialAttack()
        {
            Random dice = new Random();
            int rollTotal = 0;
            int attackDice = dice.Next(3, 9);

            for (int i = 0; i < GetAttackDices(); i++)
            {
                rollTotal += attackDice;
            }

            WriteCentered($"Special Attack ! roll : {rollTotal}");
            return rollTotal;
        }

        // -- Set standard attack stats --
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
