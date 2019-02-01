using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.ValueObjects
{
    public class Blob : ValueObject
    {
        public string FileName { get; private set; }
        public string ContentType { get; private set; }
        public string Content { get; private set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FileName;
            yield return ContentType;
            yield return Content;
        }

        public static Blob For(string content, string fileName = null, string contentType = null)
        {
            return new Blob()
            {
                Content = content,
                FileName = fileName,
                ContentType = contentType
            };
        }
    }
}