using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Farmer_vs_weeds.Audio
{
    internal class SoundControl
    {
        // -- Create a method to handle the Menu SFX --
        public static void PlaySoundEffect(string filePath)
        {
            // -- If there is already a file for a given filepath to an sfx, stop this --
            if (!File.Exists(filePath))
                return;
            // -- Create a new Audio PLayer following the filePath --
            var reader = new AudioFileReader(filePath);
            var device = new WaveOutEvent();

            device.Init(reader);
            device.Play();

            // -- When sound is over, clear the Audio Player --
            device.PlaybackStopped += (s, e) =>
            {
                device.Dispose();
                reader.Dispose();
            };
        }
    }
}
