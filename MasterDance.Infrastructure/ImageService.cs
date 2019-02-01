using System;
using System.IO;
using MasterDance.Application.Interfaces;
using SixLabors.ImageSharp;

namespace MasterDance.Infrastructure
{
    public class ImageService : DocumentStorageService, IImageService
    {
        private readonly string _basePath;

        public ImageService()
        {
            _basePath = $"{GetBasePath()}/Images";
            CreateFolderIfNotExists(_basePath);
        }

        public string SaveImageFromStringBase64(string stringBase64, string name)
        {
            using (var s = new MemoryStream(Convert.FromBase64String(stringBase64)))
            {
                var path = $"{_basePath}/${name ?? Guid.NewGuid().ToString("N")}";
                using (var fs = File.Create(name))
                {
                    var image = Image.Load(s);
                    image.SaveAsPng(fs);
                }
                return path;
            }
        }
    }
}
