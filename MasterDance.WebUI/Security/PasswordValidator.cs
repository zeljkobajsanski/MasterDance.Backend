using System.Threading.Tasks;
using IdentityServer4.Validation;

namespace MasterDance.WebUI.Security
{
    public class PasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            context.Result = new GrantValidationResult("818727", "custom");
            return Task.CompletedTask;
        }
    }
}