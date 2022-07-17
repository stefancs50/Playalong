using Playalong.Models;
using Playalong.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            for (int i = 0; i < 2; i++)
            {
                Items.Add(new Item() { Name = $"Item {i}", Length = $"{i}" });
            }
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var item = (Item)e.Item;
            Player.Play(item.FileStream);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            var fs = new FileService();
            var file = await fs.SelectFile();
            if (file == null)
                return;

            Items.Add(new Item() { Name = $"Item {file.FileName}", Length = $"00", FileStream = fs.GetStreamFromFileResult(file)});
        }
    }
}
