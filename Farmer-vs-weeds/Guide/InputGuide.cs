using Farmer_vs_weeds.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Guide
{
    internal class InputGuide
    {
        public static void InputGuideDisplay()
        {
            bool inGuide = true;

            // -- Centers Text in Console --
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

            // -- Controls loop to keep user in the guide until they exit --
            while (inGuide)
            {
                Console.Clear();
                WriteCentered("--- Class Guide ---");

                WriteCentered("");
                WriteCentered("-- Farmers --");
                WriteCentered("");
                WriteCentered("--- Simple Farmer ---");
                WriteCentered("The Simple Farmer's hit points range from 70 to 120.");
                WriteCentered("Attack is limited to 4 or 6 dice.");
                WriteCentered("Has a special attack, usable once with a 2-turn recharge.");
                WriteCentered("");
                WriteCentered("--- Chem Farmer ---");
                WriteCentered("The Chem Farmer's hit points range from 40 to 90.");
                WriteCentered("Attack is limited to 6 to 9 dice.");
                WriteCentered("Has a special attack, usable once with a 2-turn recharge.");
                WriteCentered("");
                WriteCentered("--- Tractor Farmer ---");
                WriteCentered("The Chem Farmer's hit points range from 100 to 150.");
                WriteCentered("Attack is limited to 1 to 3 dice.");
                WriteCentered("Has a special attack, usable once with a 2-turn recharge.");
                WriteCentered("");
                WriteCentered("0 - Go Back");

                // -- If user presses '0' -> return to guide menu --
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.D0)
                {
                    inGuide = false;
                    GuideMenu.Guide();
                }
            }
        }
    }
}
