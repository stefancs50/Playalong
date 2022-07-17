using Plugin.SimpleAudioPlayer;
using System.IO;

namespace Playalong.Services
{
    public class Mp3Player
    {
        public void Play(Stream file)
        {
            ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
            player.Load(file);
            player.Play();
        }
    }
}
