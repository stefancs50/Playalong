using Xamarin.Forms;

namespace Playalong.Models
{
    public class Item : BaseModel
    {
        private string name { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string length { get; set; }
        public string Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }

        public ImageSource Icon => ImageSource.FromResource("Playalong.Assets.audio.png");
    }
}
