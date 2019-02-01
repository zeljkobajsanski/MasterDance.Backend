using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MasterDance.WebUI.Extensions
{
    public static class HelperExtensions
    {
        public static string ToBase64(this IFormFile formFile)
        {
            using (var ms = new MemoryStream())
            {
                formFile.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var raw = ms.ToArray();
                return Convert.ToBase64String(raw);
            }
        }
    }
}