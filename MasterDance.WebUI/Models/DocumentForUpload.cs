using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace MasterDance.WebUI.Models
{
    public class DocumentForUpload
    {
        public int MemberId { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime? Date { get; set; }
        public IFormFile File { get; set; }
    }

    public class Validator : AbstractValidator<DocumentForUpload>
    {
        public Validator()
        {
            RuleFor(x => x.DocumentTypeId).GreaterThan(0);
            RuleFor(x => x.File).NotNull();
        }
    }
}