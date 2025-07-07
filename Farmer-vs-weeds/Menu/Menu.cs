﻿using Farmer_vs_weeds.Audio;
using Farmer_vs_weeds.Combat;
using Farmer_vs_weeds.Farmers;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Farmer_vs_weeds.Menu
{
    internal class Menu
    {
        // -- Properties --
        private static List<Farmer> Farmers = new List<Farmer>();
        private static IWavePlayer? outputDevice;
        private static AudioFileReader? audioFile;
        private static bool isMusicStarted = false;

        // -- Methods --
        public static List<Farmer> FarmersList()
        {
            return Farmers;
        }

        public static void DisplayMenu()
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
                "║        Brawling Farmers       ║",
                "║═══════════════════════════════║",
                "║                               ║",
                "║ 1 - Add Farmer                ║",
                "║ 2 - Remove Farmer             ║",
                "║ 3 - Show Farmer's List        ║",
                "║ 4 - Start a tournament        ║",
                "║ 5 - Start Singles Fight       ║",
                "║ 6 - Show previous Winners     ║",
                "║ 7 - User's Guide              ║",
                "║                               ║",
                "║ 0 - Quit                      ║",
                "╚═══════════════════════════════╝",
            };

            Console.CursorVisible = false;

            if (!isMusicStarted)
            {
                audioFile = new AudioFileReader(bgm);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                isMusicStarted = true;
                audioFile.Volume = 0.1f;
            }

            while (isMenuOn)
            {
                Console.Clear();

                // -- Center Text in Console (old way) --
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
                    SoundControl.PlaySoundEffect(selectOption);

                    switch (menuSelect)
                    {
                        case 4:
                            isMenuOn = false;
                            AddFarmerMenu.AddFarmer();
                            break;
                        case 5:
                            isMenuOn = false;
                            RemoveFarmer.RemoveFarmerMenu();
                            break;
                        case 6:
                            isMenuOn = false;
                            DisplayList.DisplayListMenu();
                            break;
                        case 7:
                            isMenuOn = false;
                            Tournament.TournamentMenu();
                            break;
                        case 8:
                            isMenuOn = false;
                            GuideMenu.Guide();
                            break;
                        case 12:
                            isMenuOn = false;
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
                            AddFarmerMenu.AddFarmer();
                            break;
                        case ConsoleKey.D2:
                            isMenuOn = false;
                            RemoveFarmer.RemoveFarmerMenu();
                            break;
                        case ConsoleKey.D3:
                            isMenuOn = false;
                            DisplayList.DisplayListMenu();
                            break;
                        case ConsoleKey.D4:
                            isMenuOn = false;
                            Tournament.TournamentMenu();
                            break;
                        case ConsoleKey.D5:
                            isMenuOn = false;
                            ChoiceFarmer.SelectFarmer();
                            break;
                        case ConsoleKey.D6:
                            isMenuOn = false;
                            ChoiceFarmer.SelectFarmer();
                            break;
                        case ConsoleKey.D7:
                            isMenuOn = false;
                            GuideMenu.Guide();
                            break;
                        case ConsoleKey.D0:
                            isMenuOn = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
