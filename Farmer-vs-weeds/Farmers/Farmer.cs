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
                WriteCentered("\nYou cannot create a farmer with negative health\n");
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
        static void WriteCentered(string text, bool newline = true)
        {
            int leftPadding = (Console.WindowWidth - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            if (newline) Console.WriteLine(text);
            else Console.Write(text);
        }

        public void ShowInfos()
        {
            WriteCentered($"\n{Username}, {Types} has {HealthPoints}hp left and {AttackDices} dices.\n");
        }
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
        public virtual int Attack()
        {
            Random dice = new Random();
            int rollTotal = 0;
            int attackDice = dice.Next(1, 6);

            for (int i = 0; i < GetAttackDices(); i++)
            {
                rollTotal += attackDice;
            }

            WriteCentered($"\nAttack ! roll : {rollTotal}\n");
            return rollTotal;
        }

        public virtual void TakeDamage(int damage)
        {
            HealthPoints -= damage;
        }
    }
}
