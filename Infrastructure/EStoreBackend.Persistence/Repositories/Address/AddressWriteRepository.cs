using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class AddressWriteRepository : WriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
