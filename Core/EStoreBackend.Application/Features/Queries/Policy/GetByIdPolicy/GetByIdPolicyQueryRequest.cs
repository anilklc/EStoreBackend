using MediatR;

namespace EStoreBackend.Application.Features.Queries.Policy.GetByIdPolicy
{
    public class GetByIdPolicyQueryRequest : IRequest<GetByIdPolicyQueryResponse>
    {
        public string Id { get; set; }
    }
}