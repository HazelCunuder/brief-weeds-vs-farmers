using Farmer_vs_weeds.Audio;
using Farmer_vs_weeds.Combat;
using Farmer_vs_weeds.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Guide
{
    internal class ClassGuide
    {
        public static void ClassGuideDisplay()
        {
            bool inGuide = true;
            

            void WriteCentered(string text, bool newline = true)
            {
                int leftPadding = (Console.WindowWidth - text.Length) / 2;
                if (leftPadding < 0)
                    leftPadding = 0;
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                if (newline)
                    Console.WriteLine(text);
                else
                    Console.Write(text);
            }

            while (inGuide)
            {
                Console.Clear();
                WriteCentered("--- Class Guide ---");

                WriteCentered("");
                WriteCentered("-- Farmers --");
                WriteCentered("");
                WriteCentered("--- Simple Farmer ---");
                WriteCentered("HPs: Between 70-120");
                WriteCentered("Attack Dices: Between 4-6");
                WriteCentered("Your standard class, they combine defense and offense to offer a more balanced type of character");
                WriteCentered("");
                WriteCentered("--- Chem Farmer ---");
                WriteCentered("HPs: Between 40-90");
                WriteCentered("Attack Dices: Between 6-9");
                WriteCentered("A true glass canon, they hit like a truck with their canisters of pesticide, but are very fragile.");
                WriteCentered("");
                WriteCentered("--- Tractor Farmer ---");
                WriteCentered("HPs: Between 100-150");
                WriteCentered("Attack Dices: Between 1-3");
                WriteCentered("Hidden in their tractor, those guys can take a lot of hits before going down, at the cost of not being able to do much damage");
                WriteCentered("");
                WriteCentered("0 - Go Back");

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.D0){
                    inGuide = false;
                    GuideMenu.Guide();
                }
            }
        }
    }
}
