using Plugin.SimpleAudioPlayer;
using System.IO;

namespace Playalong.Services
{
    public class Mp3Player
    {
        public void PlayorStop(Stream file)
        {
            ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
            if (player.IsPlaying)
            {
                player.Stop();
                file.Position = 0;
            }
            else
            {
                player.Load(file);
                player.Play();
            }
        }
    }
}
