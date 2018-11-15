using Microsoft.EntityFrameworkCore;

namespace MasterDance.Web.Data.Entities
{
    [Owned]
    public class Blob
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
    }
}