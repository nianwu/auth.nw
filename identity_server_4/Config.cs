using System.Security.Claims;
// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace identity_server_4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
            };

        public static IEnumerable<ApiResource> Apis => new ApiResource[]
        {
            new ApiResource("api1", "My API")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "client",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                // scopes that client has access to
                AllowedScopes = { "api1" }
            },
            // JavaScript Client
            new Client
            {
                ClientId = "js",
                ClientName = "JavaScript Client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,

                RedirectUris =           { "http://localhost:5003/callback.html" },
                PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                AllowedCorsOrigins =     { "http://localhost:5003" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                }
            }
        };

        public static IEnumerable<TestUser> TestUsers => new TestUser[]{
            new TestUser{
                SubjectId = "yuanzhiyuan",
                Username = "yuanzhiyuan",
                Password = "yuanzhiyuan",
                Claims = new Claim[]{
                    new Claim(ClaimTypes.Name , "袁智远"),
                    new Claim(ClaimTypes.MobilePhone, "13331070864"),
                    new Claim(ClaimTypes.Email , "1262163090@qq.com")
                }
            }
        };
    }
}