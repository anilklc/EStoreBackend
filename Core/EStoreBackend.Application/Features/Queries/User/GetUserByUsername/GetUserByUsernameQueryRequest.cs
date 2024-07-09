using MediatR;

namespace EStoreBackend.Application.Features.Queries.User.GetUserByUsername
{
    public class GetUserByUsernameQueryRequest : IRequest<GetUserByUsernameQueryResponse>
    {
        public string UserName { get; set; }
    }
}