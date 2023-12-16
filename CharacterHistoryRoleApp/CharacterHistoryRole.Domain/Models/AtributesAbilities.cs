using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class AtributesAbilities
    {
        public Guid AtributesAbilitiesId { get; set; }
        public Guid CharacterBioDetailId { get; set; }
        public string Description { get; set; }

        public virtual CharacterBioDetail CharacterBioDetail { get; set; }
    }
}
