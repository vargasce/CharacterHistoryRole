using CharacterHistoryRole.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Domain.Models
{
    public class Group : RootEntity
    {
        public Group()
        {
            UserGroups = new HashSet<UserGroup>();
        }

        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public IEnumerable<UserGroup> UserGroups { get; set; }
    }
}
