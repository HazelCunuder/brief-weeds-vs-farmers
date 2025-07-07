using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Combat
{
    internal class ChoiceFarmer
    {
        public static void SelectFarmer(List<Farmer> farmers, string playerName)
        {
            int index = -1;
            int InputUser;

            while (true)
            {
                Console.WriteLine($"\n{playerName}, choose your farmer :");
                    InputUser = Convert.ToInt32(Console.ReadLine());



            }
        }
    }
}
