using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Persistence.Repositories
{
    public class AnnouncementReadRepository : ReadRepository<Announcement>, IAnnouncementReadRepository
    {
        public AnnouncementReadRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
