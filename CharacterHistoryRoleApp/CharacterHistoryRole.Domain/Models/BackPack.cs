using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class BackPack
    {
        public Guid BackPackId { get; set; }
        public Guid CharacterBioId { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }

        public virtual CharacterBio CharacterBio { get; set; }
        public virtual IEnumerable<BackPackItem> BackPackItem { get; set; }
    }
}
