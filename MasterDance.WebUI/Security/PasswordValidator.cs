using System.Threading.Tasks;
using IdentityServer4.Validation;
using MasterDance.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MasterDance.WebUI.Security
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly MasterDanceDbContext _context;

        public PasswordValidator(MasterDanceDbContext context)
        {
            _context = context;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (context.UserName == "uuid")
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.IsActive && x.UUID == context.Password);
                if (user != null)
                {
                    context.Result = new GrantValidationResult(user.Id.ToString(), "custom");
                }
            }
            else
            {
                var user = await _context.Users.SingleOrDefaultAsync(x =>
                    x.Email == context.UserName && x.Password == context.Password && x.IsActive);
                if (user != null)
                {
                    context.Result = new GrantValidationResult(user.Id.ToString(), "custom");
                }
            }
        }
    }
}