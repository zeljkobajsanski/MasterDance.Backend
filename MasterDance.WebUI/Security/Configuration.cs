using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MasterDance.WebUI.Security
{
    public static class Configuration
    {
        public static IServiceCollection AddSecurity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentityServer(options =>
                {
                    
                })
                .AddInMemoryIdentityResources(GetIdentityResources())
                .AddInMemoryApiResources(GetApiResources())
                .AddInMemoryClients(GetClients())
                .AddDeveloperSigningCredential();
            serviceCollection.AddTransient<IResourceOwnerPasswordValidator, PasswordValidator>();
            return serviceCollection;
        }

        private static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
            };
        }

        private static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("webapi", "MasterDance web api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "webapp",
                    AllowedScopes = new List<string>()
                    {
                        "webapi"
                    },
                    ClientName = "Web app",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                }
            };
        }
    }
}