using Farmer_vs_weeds.Audio;
using Farmer_vs_weeds.Combat;
using Farmer_vs_weeds.Guide;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class GuideMenu
    {
        public static void Guide()
        {
            // -- Fetch SFX --
            string bgm = Path.Combine("Audio", "main-menu-bgm.wav");
            string scrollOptions = Path.Combine("Audio", "scroll-menu.wav");
            string selectOption = Path.Combine("Audio", "select-option.wav");

            var sfxScroll = new AudioFileReader(scrollOptions);
            var sfxSelect = new AudioFileReader(selectOption);
            var sfxDevice = new WaveOutEvent();

            bool isMenuOn = true;
            int menuSelect = 4;

            // -- Store the strings to display in the menu --
            string[] menuContent = new string[]
            {
                "╔═══════════════════════════════╗",
                "║           User Guide          ║",
                "║═══════════════════════════════║",
                "║                               ║",
                "║ 1 - Menu Guide                ║",
                "║ 2 - Classes Guide             ║",
                "║ 3 - Input Guide               ║",
                "║ 4 - Functionnalities          ║",
                "║                               ║",
                "║ 0 - Quit                      ║",
                "╚═══════════════════════════════╝",
            };

            Console.CursorVisible = false;

            while (isMenuOn)
            {
                Console.Clear();

                // -- Center Text in Console (Old Way) --
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                int menuHeight = menuContent.Length;
                int verticalPadding = (consoleHeight - menuHeight) / 2;

                // -- Add blank lines for vertical centering --
                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }

                for (int i = 0; i < menuContent.Length; i++)
                {
                    int leftPadding = (consoleWidth - menuContent[i].Length) / 2;

                    Console.SetCursorPosition(leftPadding < 0 ? 0 : leftPadding, Console.CursorTop);
                    // -- Change line color depending on the selected one --
                    if (i == menuSelect)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menuContent[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(menuContent[i]);
                        Console.ResetColor();
                    }
                }

                MenuControls();
            }

            // -- Control the menu --
            void MenuControls()
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < 9)
                {
                    menuSelect++;
                    SoundControl.PlaySoundEffect(scrollOptions);
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect > 4)
                {
                    menuSelect--;
                    SoundControl.PlaySoundEffect(scrollOptions);
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    SoundControl.PlaySoundEffect(selectOption);

                    switch (menuSelect)
                    {
                        case 4:
                            isMenuOn = false;
                            MenuGuide.GuideMenu();
                            break;
                        case 5:
                            isMenuOn = false;
                            ClassGuide.ClassGuideDisplay();
                            break;
                        case 6:
                            isMenuOn = false;
                            InputGuide.InputGuideDisplay();
                                                        break;
                        case 7:
                            isMenuOn = false;
                            Tournament.TournamentMenu();
                            break;
                        case 9:
                            isMenuOn = false;
                            Menu.DisplayMenu();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    SoundControl.PlaySoundEffect(selectOption);
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
                            isMenuOn = false;
                            MenuGuide.GuideMenu();
                            break;
                        case ConsoleKey.D2:
                            isMenuOn = false;
                            ClassGuide.ClassGuideDisplay();
                            break;
                        case ConsoleKey.D3:
                            isMenuOn = false;
                            InputGuide.InputGuideDisplay();
                            break;
                        case ConsoleKey.D4:
                            isMenuOn = false;
                            Tournament.TournamentMenu();
                            break;
                        case ConsoleKey.D0:
                            isMenuOn = false;
                            Menu.DisplayMenu();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
