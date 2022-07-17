using System.IO;
using Xamarin.Forms;

namespace Playalong.Models
{
    public class Item : BaseModel
    {
        private string name;
        private string path;
        private string length;
        private string description;
        private Stream fileStream;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }


        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public Stream FileStream
        {
            get => fileStream;
            set
            {
                fileStream = value;
                OnPropertyChanged(nameof(FileStream));
            }
        }

        public ImageSource Icon => ImageSource.FromResource("Playalong.Assets.audio.png");
    }
}
