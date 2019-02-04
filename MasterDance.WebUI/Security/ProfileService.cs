using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MasterDance.Persistence;

namespace MasterDance.WebUI.Security
{
    public class ProfileService : IProfileService
    {
        private readonly MasterDanceDbContext _context;

        public ProfileService(MasterDanceDbContext context)
        {
            _context = context;
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _context.Users.FindAsync(context.Subject.GetSubjectId());
            context.IssuedClaims.Add(new Claim(ClaimTypes.Role, user.Role));
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _context.Users.FindAsync(context.Subject.GetSubjectId());
            context.IsActive = true;
        }
    }
}