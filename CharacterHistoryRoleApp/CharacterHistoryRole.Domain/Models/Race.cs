using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class Race
    {
        public Guid RaceId { get; set; }
        public string RaceName { get; set; }

        public virtual CharacterBioDetail CharacterBioDetail { get; set; }
    }
}
