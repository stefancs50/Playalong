using Playalong.Models;
using Playalong.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Playalong
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Items{ get; set; } = new ObservableCollection<Item>();
        private Mp3Player Player { get; set; } = new Mp3Player();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var item = (Item)e.Item;
            Player.PlayorStop(item.FileStream);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var fs = new FileService();
            var path = await fs.SelectFile();
            if (path == null)
                return;
          
            var file = File.OpenRead(path);

            Items.Add(new Item() { Name = $"Item {Path.GetFileName(path)}", Length = $"{file.Length / 1024}", FileStream = file });
        }

       
    }
}
