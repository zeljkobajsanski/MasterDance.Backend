using System;
using System.IO;
using MasterDance.Application.Interfaces;

namespace MasterDance.Infrastructure
{
    public class DocumentStorageService : IDocumentStorageService
    {
        public const string RootPath = "wwwroot";

        protected void CreateFolderIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}