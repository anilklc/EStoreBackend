using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class SliderWriteRepository : WriteRepository<Slider>, ISliderWriteRepository
    {
        public SliderWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
