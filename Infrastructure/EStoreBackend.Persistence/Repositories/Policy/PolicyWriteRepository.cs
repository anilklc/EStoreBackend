using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class PolicyWriteRepository : WriteRepository<Policy>, IPolicyWriteRepository
    {
        public PolicyWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
