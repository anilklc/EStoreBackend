using MediatR;

namespace EStoreBackend.Application.Features.Queries.Address.GetByIdAddress
{
    public class GetByIdAddressQueryRequest : IRequest<GetByIdAddressQueryResponse>
    {
        public string Id { get; set; }
    }
}