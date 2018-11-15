﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace MasterDance.Web.Features.Members.Commands
{
    public class AddDocument
    {
        public class Command : IRequest<int>
        {
            public int MemberId { get; set; }
            public int DocumentTypeId { get; set; }
            public DateTime? Date { get; set; }
            public IFormFile File { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.DocumentTypeId).GreaterThan(0);
                RuleFor(x => x.MemberId).GreaterThan(0);
                RuleFor(x => x.File).NotNull();
            }
        }

        public class CommandHanlder : IRequestHandler<Command, int>
        {
            private readonly MasterDanceContext _context;

            public CommandHanlder(MasterDanceContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Date = DateTime.Now;
                var document = new Document
                {
                    Date = DateTime.Now,
                    MemberId = request.MemberId,
                    TypeId = request.DocumentTypeId
                };
                using (var ms = new MemoryStream())
                {
                    await request.File.CopyToAsync(ms, cancellationToken);
                    ms.Seek(0, SeekOrigin.Begin);
                    var content = Convert.ToBase64String(ms.GetBuffer());
                    string contentType = null;
                    try
                    {
                        contentType = request.File.ContentType;
                    } catch { }

                    document.Content = new Blob()
                    {
                        FileName = request.File.FileName,
                        ContentType = contentType,
                        Content = content
                    };
                }
                _context.Documents.Add(document);
                await _context.SaveChangesAsync(cancellationToken);
                return document.Id;
            }
        }

    }
}