using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EStoreBackend.Application.Features.Queries.Product.GetProductDetail
{
    public class GetProductDetailQueryRequest : IRequest<GetProductDetailQueryRespnose>
    {
        public string Id { get; set; }
    }
}