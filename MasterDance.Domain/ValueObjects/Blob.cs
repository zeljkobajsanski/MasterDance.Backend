using System.Collections.Generic;
using MasterDance.Domain.Infrastructure;

namespace MasterDance.Domain.ValueObjects
{
    public class Blob : ValueObject
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FileName;
            yield return ContentType;
            yield return Content;
        }
    }
}