using EStoreBackend.Application.DTOs.Product;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProductAdmin
{
    public class GetAllProductAdminQueryResponse
    {
        public List<GetAllProductAdminDto> Products {  get; set; } 
    }
}