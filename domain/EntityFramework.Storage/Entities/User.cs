using System.Collections.Generic;
using domain.Storage.Entities;

namespace domain.EntityFramework.Storage.Entities
{
    public class User : Models.User
    {
        public new ICollection<UserClaim> Claims { get; set; }
    }
}