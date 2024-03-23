using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Common;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Persistence.Repositories
{
    public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
    {
        public AboutReadRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
