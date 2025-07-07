using System.Net.Mail;

namespace Farmer_vs_weeds
{
    internal class Farmer
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
                Console.WriteLine("You cannot create a farmer with negative health");
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

        public void ShowInfos()
        {
            Console.WriteLine(
                $"{Username}, {Types} has {HealthPoints}hp left and {AttackDices} dices."
            );
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

            Console.WriteLine(rollTotal);
            return rollTotal;
        }

        public virtual void TakeDamage(int damage)
        {
            HealthPoints -= damage;
        }
    }
}
