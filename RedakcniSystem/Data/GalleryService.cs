using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedakcniSystem.Data.Models;
using System.IO;

namespace RedakcniSystem.Data
{
    public class GalleryService
    {
        public IWebHostEnvironment _environment { get; set; }
        public GalleryService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public List<Album> GetAlbums()
        {
            List<Album> albums = new List<Album>();

            DirectoryInfo info = new DirectoryInfo(@$"{_environment.ContentRootPath}/wwwroot/Gallery/");

            foreach (var dir in info.GetDirectories())
            {
                var imgName = "";
                if (dir.GetFiles().Length != 0)
                {
                    imgName = dir.GetFiles().FirstOrDefault().Name;
                }
                albums.Add(
                    new Album()
                    {
                        Name = dir.Name,
                        ImageUrl = $"/Gallery/{dir.Name}/{imgName}"
                    }
                );
            }

            return albums;
        }
        public List<string> GetImages(string albumName)
        {
            List<string> images = new List<string>();

            DirectoryInfo dir = new DirectoryInfo($@"{_environment.ContentRootPath}/wwwroot/Gallery/{albumName}");

            foreach (var img in dir.GetFiles())
            {
                images.Add($"/Gallery/{albumName}/{img.Name}");
            }
            return images;
        }
        public void DeleteImage(string albumName, string imageName)
        {
            DirectoryInfo dir = new DirectoryInfo($@"{_environment.ContentRootPath}/wwwroot/Gallery/{albumName}");
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                if(file.Name == imageName)
                {
                    file.Delete();
                    return;
                }
            }
        }
        public void CreateAlbum(string name)
        {
            DirectoryInfo dir = new DirectoryInfo($@"{_environment.ContentRootPath}/wwwroot/Gallery");
            dir.CreateSubdirectory(name);
        }
        public async Task SaveImage(MemoryStream image, string albumName)
        {
            var array = image.ToArray();
            await File.WriteAllBytesAsync($@"{_environment.ContentRootPath}/wwwroot/Gallery/{albumName}", array);
        }
    }
}
