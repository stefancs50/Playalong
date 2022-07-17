
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
        public async Task<FileResult> SelectFile()
        {
            try
            {
           
                var result = await FilePicker.PickAsync(PickOptions.Default);
                if (result != null)
                {
                    if (result.FileName.EndsWith("mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }

        public async Task SaveFile()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        }

        public Stream GetStreamFromFileResult(FileResult fr) => new FileStream(fr.FullPath, FileMode.Open, FileAccess.Read);
    }
}
