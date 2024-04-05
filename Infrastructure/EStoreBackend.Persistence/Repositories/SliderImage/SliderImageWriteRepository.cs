using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class SliderImageWriteRepository : WriteRepository<SliderImage>, ISliderImageWriteRepository
    {
        public SliderImageWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
