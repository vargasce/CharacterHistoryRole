using CharacterHistoryRole.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class CharacterBio : RootEntity
    {
        public CharacterBio()
        {
            BackPack = new HashSet<BackPack>();
            UserGroup = new HashSet<UserGroup>();
        }
        public Guid CharacterBioId { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public string BioInfo { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public bool? IsPublic { get; set; }
        public int? Experience { get; set; }

        public virtual IEnumerable<BackPack> BackPack { get; set; }
        public virtual IEnumerable<UserGroup> UserGroup { get; set; }
        public virtual User User { get; set; }
        public virtual CharacterBioDetail CharacterBioDetail { get; set; }
    }
}
