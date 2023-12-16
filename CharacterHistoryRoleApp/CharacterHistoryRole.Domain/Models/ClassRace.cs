using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class ClassRace
    {
        public Guid ClassRaceId { get; set; }
        public string ClassRaceName { get; set; }

        public virtual CharacterBioDetail CharacterBioDetail { get; set; }
    }
}
