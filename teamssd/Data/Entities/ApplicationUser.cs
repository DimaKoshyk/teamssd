using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Payzaar.Core.Data.Abstract;

namespace teamssd.Data.Entities
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        [DisplayName("Ім'я")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AvatarUri { get; set; }
        public string AvatarThumbnailUri { get; set; }

        public bool IsDeleted { get; set; }


        public virtual ICollection<View> ViewedNews { get; set; }
        public virtual ICollection<InterestNews> InterestNews { get; set; }
        public virtual ICollection<RelevantNews> RelevantNews { get; set; }
        public virtual ICollection<UsefulNews> UsefulNews { get; set; }

        public virtual ICollection<Chanel> Chanels { get; set; }

        public virtual ICollection<Follower> FollowedChanels { get; set; }

        #region Identity methods

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        #endregion
    }
}