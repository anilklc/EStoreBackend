using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EStoreBackend.Application.Features.Commands.Prdouct.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public IFormFile FormFile { get; set; }
     //   public string ProductCoverImagePath { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        [ForeignKey("Stock")]
        public Guid StockId { get; set; }
    }
}