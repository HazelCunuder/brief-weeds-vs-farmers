namespace Farmer_vs_weeds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isFightOver = false;

            TractorFarmer john = new TractorFarmer("John", 150, 1,true);
            ChemFarmer terry = new ChemFarmer("Terry", 90, 9);

            while (!isFightOver)
            {
                if (john.GetHPs() > 0 && terry.GetHPs() > 0)
                {
                    terry.TakeDamage(john.Attack());
                    terry.ShowInfos();

                    if (john.GetHPs() <= 0 || terry.GetHPs() <= 0)
                    {
                        string winner;
                        if (john.GetHPs() > terry.GetHPs())
                        {
                            winner = "John";
                        }
                        else
                        {
                            winner = "Terry";
                        }
                        Console.WriteLine(winner + " has won the fight!");
                        isFightOver = true;
                    }
                    else
                    {
                        john.TakeDamage(terry.Attack());
                        john.ShowInfos();
                    }
                }
                else if (john.GetHPs() <= 0)
                {
                    string winner;
                    if (john.GetHPs() > terry.GetHPs())
                    {
                        winner = "John";
                    }
                    else
                    {
                        winner = "Terry";
                    }
                    Console.WriteLine(winner + " has won the fight!");
                    isFightOver = true;
                }
            }

            Console.ReadKey();
        }
    }
}
