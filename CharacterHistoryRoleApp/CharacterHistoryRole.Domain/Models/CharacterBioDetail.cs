using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class CharacterBioDetail
    {
        public CharacterBioDetail()
        {
            AtributesAbilities = new HashSet<AtributesAbilities>();
            RacialBackground = new HashSet<RacialBackground>();
        }
        public Guid CharacterBioDetailId { get; set; }
        public Guid? ClassRaceId { get; set; }
        public Guid? RaceId { get; set; }
        public Guid CharacterBioId { get; set; }
        public int? Force { get; set; }
        public int? Destress { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Perception { get; set; }
        public int? Level { get; set; }
        public int? LifePoints { get; set; }
        public int? PowerPoints { get; set; }

        public virtual Race Race { get; set; }
        public virtual ClassRace ClassRace { get; set; }
        public virtual IEnumerable<AtributesAbilities> AtributesAbilities { get; set; }
        public virtual IEnumerable<RacialBackground> RacialBackground { get; set; }
        public virtual CharacterBio CharacterBio { get; set; }

    }
}
