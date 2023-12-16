using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class UserGroup
    {
        public UserGroup()
        {

        }

        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
        public virtual CharacterBio CharacterBio { get; set; }
    }
}
