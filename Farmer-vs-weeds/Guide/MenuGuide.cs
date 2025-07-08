using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Guide
{
    internal class MenuGuide
    {
        public static void GuideMenu()
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
                WriteCentered("--- Menu Guide ---");

                WriteCentered("");
                WriteCentered("-- Add and Remove Farmer --");
                WriteCentered("");
                WriteCentered("Allows you to add and remove farmers to use in battle");
                WriteCentered("");
                WriteCentered("-- Show Farmer's List --");
                WriteCentered("");
                WriteCentered("Displays all of the farmers created");
                WriteCentered("");
                WriteCentered("-- Start a tournament --");
                WriteCentered("");
                WriteCentered("Choose one of your fartmers and fight multiple others until you are the last farmer standing");
                WriteCentered("");
                WriteCentered("-- Start Singles Fight --");
                WriteCentered("");
                WriteCentered("Choose 2 farmers and watch them go head to head");
                WriteCentered("");
                WriteCentered("-- Show previous Winners --");
                WriteCentered("");
                WriteCentered("Displays the last 5 winners of a fight or tournament");
                WriteCentered("");
                WriteCentered("-- User's Guide --");
                WriteCentered("");
                WriteCentered("Shows you info on the different features of this game");
                WriteCentered("");
                WriteCentered("0 - Go Back");

                // -- If user presses '0' -> return to guide menu --
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.D0)
                {
                    inGuide = false;
                    Menu.GuideMenu.Guide();
                }
            }
        }
    }
}
