using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using MasterDance.Common;
using MasterDance.Persistence;
using Microsoft.EntityFrameworkCore;

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
            if (context.Client.ClientId == "mobileapp")
            {
                return;
            }
            var user = await _context.Users.SingleAsync(x => x.Id == int.Parse(context.Subject.GetSubjectId()));
            context.IssuedClaims.Add(new Claim(ClaimTypes.Role, user.Role));
            context.IssuedClaims.Add(new Claim(Constants.CustomClaims.PersonId, user.PersonId.ToString()));
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            if (context.Client.ClientId == "mobileapp")
            {
                context.IsActive = true;
                return;
            }
            var user = await _context.Users.FindAsync(int.Parse(context.Subject.GetSubjectId()));
            context.IsActive = user.IsActive;
        }
    }
}