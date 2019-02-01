using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Documents.Models
{
    public static class Extensions
    {
        public static DocumentTypeModel ToModel(this DocumentType documentType)
        {
            return new DocumentTypeModel() {Id = documentType.Id, Name = documentType.Name};
        }

        public static DocumentModel ToModel(this Document document)
        {
            return new DocumentModel() {FileName = document.Content?.FileName, Content = document.Content?.Content};
        }
    }
}