using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class ProfilePermmission
    {
        public ProfilePermmission()
        {            
        }

        public Guid ProfileId { get; set; }
        public int PermmissionId { get; set; }
        public virtual Permmission Permmission { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual User User { get; set; }
    }
}
