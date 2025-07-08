using Farmer_vs_weeds.Audio;
using NAudio.Wave;

namespace Farmer_vs_weeds.Menu
{
    internal class AddFarmerMenu
    {
        // -- Methods --
        public static void AddFarmer()
        {
            // -- Add SFX --
            string bgm = Path.Combine("Audio", "main-menu-bgm.wav");
            string scrollOptions = Path.Combine("Audio", "scroll-menu.wav");
            string selectOption = Path.Combine("Audio", "select-option.wav");

            var sfxScroll = new AudioFileReader(scrollOptions);
            var sfxSelect = new AudioFileReader(selectOption);
            var sfxDevice = new WaveOutEvent();

            int menuSelect = 4;

            bool addFarmer = true;

            // -- Store the lines we'll need to display --
            string[] display = new string[]
            {
                "--- Add a Farmer ---",
                " ",
                "Create new Farmer",
                " ",
                "1 - Classic Farmer",
                "2 - Chem Farmer",
                "3 - Tractor Farmer",
                " ",
                "0 - Go Back",
            };

            while (addFarmer)
            {
                Console.Clear();
                DisplayFarmer();

                MenuControls();
            }

            // -- Control the menu --
            void MenuControls()
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < 11)
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
                    switch (menuSelect)
                    {
                        case 4:
                            AddSimpleFarmer.SimpleFarmer();
                            break;
                        case 5:
                            AddChemFarmer.ChemFarmer();
                            break;
                        case 6:
                            AddTractorFarmer.TractorFarmer();
                            break;
                        case 8:
                            addFarmer = false;
                            Menu.DisplayMenu();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            AddSimpleFarmer.SimpleFarmer();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            AddChemFarmer.ChemFarmer();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            AddTractorFarmer.TractorFarmer();
                            break;
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            addFarmer = false;
                            Console.Clear();
                            Menu.DisplayMenu();
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
            }

            void DisplayFarmer()
            {
                // -- Centers Text in Console (Old version) --
                int consoleWidth = Console.WindowWidth;
                int consoleHeight = Console.WindowHeight;

                int menuHeight = display.Length;
                int verticalPadding = (consoleHeight - menuHeight) / 2;

                for (int i = 0; i < verticalPadding; i++)
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < display.Length; i++)
                {
                    int leftPadding = (consoleWidth - display[i].Length) / 2;

                    Console.SetCursorPosition(leftPadding < 0 ? 0 : leftPadding, Console.CursorTop);

                    // -- Change line color depending on the selected one --
                    if (i == menuSelect)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(display[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(display[i]);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
