using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using MasterDance.Common;
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
            serviceCollection.AddTransient<IProfileService, ProfileService>();
            serviceCollection.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
#if DEBUG
                    options.Authority = "http://localhost:5000";
#endif
#if RELEASE
                   options.Authority = "https://masterdance.bitseverywhere.rs";
# endif
                    options.RequireHttpsMetadata = false;
                    options.Audience = "webapi";
                });
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
                {
                    UserClaims = new List<string>()
                    {
                        Constants.CustomClaims.PersonId
                    }
                }
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
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime = 45 * 24 * 3600,
                },
                new Client()
                {
                    ClientId = "mobileapp",
                    AllowedScopes = new List<string>()
                    {
                        "webapi"
                    },
                    ClientName = "Mobile app",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = new List<string>(){"http://localhost:8100"}
                }
            };
        }
    }
}