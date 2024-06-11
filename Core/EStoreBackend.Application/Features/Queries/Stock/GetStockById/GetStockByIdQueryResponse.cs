namespace EStoreBackend.Application.Features.Queries.Stock.GetStockById
{
    public class GetStockByIdQueryResponse
    {
        public string Id { get; set; }
        public string ProductSize { get; set; }
        public int ProductStock { get; set; }
        public Guid ProductId { get; set; }
    }
}