using System;
using FluentValidation;

namespace MasterDance.Application.UseCases.Members.Models
{
    public class DocumentModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int MemberId { get; set; }
        public int DocumentType { get; set; }
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Content { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}