using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class DisplayList
    {
        public static void DisplayListMenu()
        {
            bool displayListMenuOn = true;

            List<string> listContent = new List<string>
            {
                "╔════════════════════════════════╗",
                "║          Farmer's List         ║",
                "╚════════════════════════════════╝",
                "                                  ",
            };

            // -- Add every farmer in the Farmer List to the List to display --
            for (int i = 0; i < Menu.FarmersList().Count; i++)
            {
                string farmerLine =
                    $"{i + 1} - {Menu.FarmersList()[i].GetUsername()}, HP: {Menu.FarmersList()[i].GetHPs()}, Attack Dices {Menu.FarmersList()[i].GetAttackDices()}";
                listContent.Add(farmerLine);
            }

            listContent.Add("\n");
            listContent.Add("0 - Go Back");

            while (displayListMenuOn)
            {
                Console.Clear();
                Console.CursorVisible = false;

                // -- Centers Text in Console (Old way) --
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                int menuHeight = listContent.Count;
                int verticalPadding = (consoleHeight - menuHeight) / 2;

                // -- Add blank lines for vertical centering --
                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }

                for (int i = 0; i < listContent.Count; i++)
                {
                    int leftPadding = (consoleWidth - listContent[i].Length) / 2;

                    Console.SetCursorPosition(leftPadding < 0 ? 0 : leftPadding, Console.CursorTop);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(listContent[i]);
                    Console.ResetColor();
                }
                ControlMenu();
            }

            // -- Return to Main Men,u if '0' is pressed --
            void ControlMenu()
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D0:
                        Console.Clear();
                        displayListMenuOn = false;
                        Menu.DisplayMenu();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
