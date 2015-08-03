using Login.API.Entities;

namespace Login.API.Migrations
{
    using Login.API.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuthContext context)
        {
            if (context.Clients.Any())
            {
                return;
            }

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        private static IEnumerable<Client> BuildClientsList()
        {

            var clientsList = new List<Client> 
            {
                new Client
                { Id = "Depict", 
                    Secret= Helper.GetHash("abc@123"), 
                    Name="Photo voting application", 
                    ApplicationType =  Models.ApplicationTypes.JavaScript, 
                    Active = true, 
                    RefreshTokenLifeTime = 7200, 
                    AllowedOrigin = "*"
                },
                new Client
                { Id = "consoleApp", 
                    Secret=Helper.GetHash("123@abc"), 
                    Name="Console Application", 
                    ApplicationType =Models.ApplicationTypes.NativeConfidential, 
                    Active = true, 
                    RefreshTokenLifeTime = 14400, 
                    AllowedOrigin = "*"
                }
            };

            return clientsList;
        }
    }
}
