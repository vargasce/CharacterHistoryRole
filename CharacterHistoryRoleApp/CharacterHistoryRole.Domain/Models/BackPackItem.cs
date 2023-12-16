using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class BackPackItem
    {
        public Guid BackPackItemId { get; set; }
        public Guid BackPackId { get; set; }
        public string Description { get; set; }

        public virtual BackPack BackPack { get; set; }
    }
}
