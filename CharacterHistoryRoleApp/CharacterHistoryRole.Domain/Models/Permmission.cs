using CharacterHistoryRole.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class Permmission : RootEntity
    {
        public Permmission()
        {
            ProfilePermmission = new HashSet<ProfilePermmission>();
        }
        public int PermmissionId { get; set; }
        public string PermmissionName { get; set; }

        public virtual IEnumerable<ProfilePermmission> ProfilePermmission { get; set; }
    }
}
