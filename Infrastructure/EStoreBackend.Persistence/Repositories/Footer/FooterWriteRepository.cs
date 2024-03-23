using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class FooterWriteRepository : WriteRepository<Footer>, IFooterWriteRepository
    {
        public FooterWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
