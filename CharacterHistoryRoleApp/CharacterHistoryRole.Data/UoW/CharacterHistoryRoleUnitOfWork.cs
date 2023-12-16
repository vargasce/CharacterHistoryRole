using AutoMapper;
using CharacterHisotryRole.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Data.UoW
{
    public class CharacterHistoryRoleUnitOfWork : BaseUnitOfWork
    {
        public CharacterHistoryRoleUnitOfWork(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
