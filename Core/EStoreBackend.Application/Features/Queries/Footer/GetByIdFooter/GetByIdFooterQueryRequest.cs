using MediatR;

namespace EStoreBackend.Application.Features.Queries.Footer.GetByIdFooter
{
    public class GetByIdFooterQueryRequest : IRequest<GetByIdFooterQueryRespnose>
    {
        public string Id { get; set; }
    }
}