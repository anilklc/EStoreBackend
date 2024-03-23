using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class FeatureWriteRepository : WriteRepository<Feature>, IFeatureWriteRepository
    {
        public FeatureWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
