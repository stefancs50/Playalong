
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Playalong.Services
{
    public class FileService
    {
        public async Task<string> SelectFile()
        {
            try
            {
           
                var result = await FilePicker.PickAsync(PickOptions.Default);
                if (result != null)
                    if (result.FileName.EndsWith("mp3", StringComparison.OrdinalIgnoreCase))
                        return await SaveFile(result);
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<string> SaveFile(FileResult fr)
        {
            string savedpath = string.Empty;
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                savedpath = Path.Combine(path, fr.FileName);
                var deststream = File.Create(savedpath);

                var stream = await fr.OpenReadAsync();
                await stream.CopyToAsync(deststream);
                deststream.Close();
            }
            catch (Exception ex)
            {
            }
            return savedpath;
        }
    }
}
