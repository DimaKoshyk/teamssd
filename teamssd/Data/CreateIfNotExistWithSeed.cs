using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using teamssd.Data.Entities;

namespace teamssd.Data
{
    public class CreateIfNotExistWithSeed : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        private const string UserPasswrod = "Adm!nDex";
        private const string EmailDomain = "@payzaar.com";
        private const string TserpiakLastName = "Tserpiak";
        private const string KoshykLastName = "Koshyk";
        private const string VerbytskaLastName = "Verbytska";
        private const string KovalLastName = "Koval";

        private static readonly IList<string> AdminEmails = new List<string>
        {
            TserpiakLastName + EmailDomain,
            KoshykLastName + EmailDomain,
            VerbytskaLastName + EmailDomain,
            KovalLastName + EmailDomain
        };

        private static readonly string[][] Profiles =
        {
            new[] {"Vasya", TserpiakLastName},
            new[] {"Dmytro", KoshykLastName},
            new[] {"Ira", VerbytskaLastName},
            new[] {"Victor", KovalLastName},
            new[] {"Petro", "Petrenko"},
            new[] {"James", "Bond"},
            
        };

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeDb(context);
        }

        public static void InitializeDb(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                Init(context);
            }
        }

        private static void Init(ApplicationDbContext context)
        {
            InitUsers(context);
        }

        public static void InitUsers(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userHelper = new UserHelper(context);
            //var emails = new List<string>();
            foreach (var profile in Profiles)
            {
                var email = profile[1] + EmailDomain;
                var user = userHelper.GetUser(email);

                if (user != null) continue;

                user = new ApplicationUser
                {
                    FirstName = profile[0],
                    LastName = profile[1],
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                };

                if (profile[1] == "Bond")
                {
                    user.PhoneNumber = "+380123456789";
                    user.PhoneNumberConfirmed = true;
                }

                userManager.Create(user, UserPasswrod);
                context.SaveChanges();
                
            }
            context.SaveChanges();
        }
        private class UserHelper
        {
            public UserHelper(ApplicationDbContext context)
            {
                Context = context;
            }

            private ApplicationDbContext Context { get; set; }

            public ApplicationUser GetUser(string email)
            {
                return Context.Users.FirstOrDefault(u => u.Email.Equals(email));
            }
        }
    }
}