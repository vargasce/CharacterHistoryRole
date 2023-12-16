using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Core.Models
{
    public class RootEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }

        [Timestamp]
        public byte[]? CurrentTimestamp { get; set; }
    }
}
