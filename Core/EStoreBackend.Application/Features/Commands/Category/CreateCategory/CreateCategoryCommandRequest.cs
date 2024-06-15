using MediatR;

namespace EStoreBackend.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }
    }
}