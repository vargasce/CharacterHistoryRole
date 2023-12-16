using CharacterHistoryRole.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class Profile : RootEntity
    {
        public Profile()
        {
            ProfilePermmission = new HashSet<ProfilePermmission>();
        }

        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual IEnumerable<ProfilePermmission> ProfilePermmission { get; set; }
    }
}
