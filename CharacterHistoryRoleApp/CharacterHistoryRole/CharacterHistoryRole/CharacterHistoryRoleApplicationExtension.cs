using CharacterHistoryRole.Data.UoW;
using CharacterHistoryRole.Domain.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterHistoryRole.Application
{
    public static class CharacterHistoryRoleApplicationExtension
    {
        public static IServiceCollection AddCharacterHistoryRoleApplicationExtension(this IServiceCollection service) {

            service.AddScoped<IUnitOfWork, CharacterHistoryRoleUnitOfWork>();
            return service;
        }
    }
}
