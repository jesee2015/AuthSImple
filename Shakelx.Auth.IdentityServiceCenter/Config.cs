using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Shakelx.Auth.IdentityServiceCenter
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes= GrantTypes.ClientCredentials,

                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes={"api"},
                }
            };
        }

    }
}
