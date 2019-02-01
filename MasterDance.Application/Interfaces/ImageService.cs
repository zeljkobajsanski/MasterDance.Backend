namespace MasterDance.Application.Interfaces
{
    public interface IImageService : IDocumentStorageService
    {
        string SaveImageFromStringBase64(string stringBase64, string fileName = null);
    }
}
