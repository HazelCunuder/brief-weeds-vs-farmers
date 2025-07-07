using System.Net.Mail;
using Farmer_vs_weeds.Menu;

namespace Farmer_vs_weeds
{
    public class Farmer
    {
        // -- Properties Statements --
        private string Username { get; set; }
        private int HealthPoints { get; set; }
        private int AttackDices { get; set; }
        private string Types { get; set; }

        // -- Constructor Statement --
        public Farmer(string username, int healthpoints, int attackDices, string types)
        {
            Types = types;
            Username = username;
            AttackDices = attackDices;
            if (healthpoints < 0)
            {
                WriteCentered("You cannot create a farmer with negative health");
            }
            else
            {
                HealthPoints = healthpoints;
            }
        }

        // -- Getter Setters --
        public string GetUsername()
        {
            return Username;
        }

        public int GetHPs()
        {
            return HealthPoints;
        }

        public void SetHealthPoints(int healthPoints)
        {
            HealthPoints = healthPoints;
        }

        public int GetAttackDices()
        {
            return AttackDices;
        }

        public string GetTypes()
        {
            return Types;
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

        // -- Displays info on the current Farmer --
        public void ShowInfos()
        {
            WriteCentered($"{Username}, {Types} has {HealthPoints}hp left and {AttackDices} dices.");
        }

        // -- Base for all special attacks --
        public virtual int SpecialAttack()
        {
            Random dice = new Random();
            int rollTotal = 0;
            int attackDice = dice.Next(3, 9);

            for (int i = 0; i < GetAttackDices(); i++)
            {
                rollTotal += attackDice;
            }

            WriteCentered($"\nSpecial Attack ! roll : {rollTotal}\n");
            return rollTotal;
        }

        // -- Base for all standard attacks --
        public virtual int Attack()
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

        // -- Remove the damage from the Farmer's health --
        public virtual void TakeDamage(int damage)
        {
            HealthPoints -= damage;
        }
    }
}
