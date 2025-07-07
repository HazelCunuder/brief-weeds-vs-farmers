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
        public static void PlaySoundEffect(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            var reader = new AudioFileReader(filePath);
            var device = new WaveOutEvent();

            device.Init(reader);
            device.Play();

            device.PlaybackStopped += (s, e) =>
            {
                device.Dispose();
                reader.Dispose();
            };
        }
    }
}
