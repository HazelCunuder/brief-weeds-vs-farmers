using System.Runtime.CompilerServices;

namespace Farmer_vs_weeds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isFightOver = false;
            
            Farmer john = new Farmer("John Doe", 100, 4);
            

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
