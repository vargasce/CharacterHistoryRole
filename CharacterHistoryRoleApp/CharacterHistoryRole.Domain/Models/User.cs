using CharacterHistoryRole.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class User : RootEntity
    {
        public User()
        {
            ProfilePermmissions = new HashSet<ProfilePermmission>();
            CharacterBio = new HashSet<CharacterBio>();
            UserGroups = new HashSet<UserGroup>();
        }

        public Guid UserId { get; set; }
        public Guid ProfileId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public bool Active { get; set; }
        
        public virtual IEnumerable<ProfilePermmission> ProfilePermmissions { get; set; }
        public virtual IEnumerable<UserGroup> UserGroups { get; set; }
        public virtual IEnumerable<CharacterBio> CharacterBio { get; set; }
    }
}
