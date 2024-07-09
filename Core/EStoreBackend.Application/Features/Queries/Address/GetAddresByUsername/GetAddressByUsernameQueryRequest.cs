using MediatR;

namespace EStoreBackend.Application.Features.Queries.Address.GetAddressByUsername
{
    public class GetAddressByUsernameQueryRequest : IRequest<GetAddressByUsernameQueryResponse>
    {
        public string userName { get; set; }
    }
}