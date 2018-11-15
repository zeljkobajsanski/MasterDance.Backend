using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MasterDance.Web.Data;
using MasterDance.Web.Features.Members.Commands;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MasterDance.UnitTests.Features.Members
{
    public class MembersTests
    {
        private readonly MasterDanceContext _context;

        public MembersTests()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase("MasterDance.UnitTests").Options;
            _context = new MasterDanceContext(options);
        }

        [Fact]
        public async Task AddDocument()
        {
            using (var s = Assembly.GetAssembly(typeof(MembersTests)).GetManifestResourceStream("MasterDance.UnitTests.TestData.SkateOrder.pdf"))
            {
                var request = new AddDocument.Command()
                {
                    MemberId = 1,
                    DocumentTypeId = 1,
                    File = new FormFile(s, 0, s.Length, "file", "SkateOrder.pdf")
                };
                var id = await new AddDocument.CommandHanlder(_context).Handle(request, CancellationToken.None);

                var document =  await _context.Documents.FindAsync(id);
                Assert.NotNull(document);
                Assert.Equal(request.MemberId, document.Id);
                Assert.Equal(request.DocumentTypeId, document.TypeId);
                Assert.NotNull(document.Content);
                Assert.Equal("SkateOrder.pdf", document.Content.FileName);
                Assert.NotEmpty(document.Content.Content);
            }
            
        }
    }
}