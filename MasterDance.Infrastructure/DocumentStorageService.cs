using System.IO;
using MasterDance.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MasterDance.Infrastructure
{
    public class DocumentStorageService : IDocumentStorageService
    {
        protected string RootFolder;

        public DocumentStorageService(IConfiguration configuration)
        {
            var rootFolder = configuration.GetSection("MasterDance")["WebRoot"];
            RootFolder = rootFolder;
        }

        protected void CreateFolderIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}