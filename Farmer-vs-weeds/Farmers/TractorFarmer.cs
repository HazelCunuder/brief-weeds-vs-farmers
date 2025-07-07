namespace Farmer_vs_weeds.Farmers
{
    internal class TractorFarmer : Farmer
    {
        // -- Attributes --

        private readonly bool inTractor;

        // -- Constructor Statement --

        public TractorFarmer(
            string username,
            int healthPoints,
            int attackDices,
            bool isInTractor,
            string types
        )
            : base(username, healthPoints, attackDices, types)
        {
            inTractor = isInTractor;

            bool correctTractorFarmerHP = false;

            while (!correctTractorFarmerHP)
            {
                if (healthPoints < 0)
                {
                    Console.WriteLine(
                        "You cannot create a Automatic farmer with negative health\n"
                    );
                    Console.Write("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (healthPoints < 100)
                {
                    Console.WriteLine("You cannot create a Automic Farmer with less than 100HP\n");
                    Console.Write("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else if (healthPoints > 150)
                {
                    Console.WriteLine(
                        "You cannot create a Automatic Farmer with more than 150HP\n"
                    );
                    Console.Write("Please write a correct HP value: ");
                    healthPoints = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else
                {
                    this.SetHealthPoints(healthPoints);
                    correctTractorFarmerHP = true;
                }
            }
        }

        // -- Methods --

        public override void TakeDamage(int damage)
        {
            if (inTractor == true)
            {
                Console.WriteLine(
                    $"{GetUsername()} is in the tractor, they will now take half damage"
                );

                int currentHP = GetHPs();
                SetHealthPoints(currentHP - damage / 2);
            }
        }
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
