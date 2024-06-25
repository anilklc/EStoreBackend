using MediatR;

namespace EStoreBackend.Application.Features.Queries.User
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
    }
}