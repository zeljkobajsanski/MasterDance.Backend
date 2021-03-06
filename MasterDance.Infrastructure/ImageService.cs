﻿using System;
using System.IO;
using MasterDance.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;

namespace MasterDance.Infrastructure
{
    public class ImageService : DocumentStorageService, IImageService
    {
        private readonly string _basePath;
        

        public ImageService(IConfiguration configuration) : base(configuration)
        {
            _basePath = $"{RootFolder}/Images";
            CreateFolderIfNotExists(_basePath);
        }

        public string SaveImageFromStringBase64(string stringBase64, string name)
        {
            if (string.IsNullOrEmpty(stringBase64) || !stringBase64.StartsWith("data:")) return stringBase64;
            
            var ix = stringBase64.IndexOf("base64,", StringComparison.InvariantCulture);
            stringBase64 = stringBase64.Substring(ix + 7);
            
            using (var s = new MemoryStream(Convert.FromBase64String(stringBase64)))
            {
                name = $"{name ?? Guid.NewGuid().ToString("N")}.png";
                var path = $"{_basePath}/{name}";
                using (var fs = File.Create(path))
                {
                    var image = Image.Load(s);
                    image.SaveAsPng(fs);
                }

                return $"/Images/{name}";
            }
        }
    }
}
