using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

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

                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes={"api"},
                },
                new Client  //添加resource owner password credentials 客户端
                {
                    ClientId="pwdClient",
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,

                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api"},
                }
            };
        }

        /// <summary>
        /// 添加测试用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "===========",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }

            };
        }

    }
}
