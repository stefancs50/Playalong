using Playalong.Models;
using Playalong.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Playalong
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Items{ get; set; } = new ObservableCollection<Item>();
      
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            for (int i = 0; i < 2; i++)
            {
                Items.Add(new Item() { Name = $"Item {i}", Length = $"{i}" });
            }
        }

        private void lstProducts_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var fs = new FileService();
            var files = await fs.SelectFiles();
            if (files == null)
                return;

            Items.Add(new Item() { Name = $"Item {files.FileName}", Length = $"00" });
        }
    }
}
