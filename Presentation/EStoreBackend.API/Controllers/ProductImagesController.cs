using EStoreBackend.Application.Features.Commands.ProductImage.CreateProductImage;
using EStoreBackend.Application.Features.Commands.ProductImage.RemoveProductImage;
using EStoreBackend.Application.Features.Commands.ProductImage.UpdateProductImage;
using EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageByProductId;
using EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{ProductId}")]
        public async Task<IActionResult> GetProductImageByProductId([FromRoute] GetProductImageByProductIdQueryRequest request)
        {
            GetProductImageByProductIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImageById([FromRoute] GetProductImageByIdQueryRequest request)
        {
            GetProductImageByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProductImage(IFormFile formFile, string ProductId)
        {
            CreateProductImageCommandRequest request = new() { FormFile = formFile, ProductId = ProductId };
            CreateProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductImage(IFormFile formFile, string id)
        {
            UpdateProductImageCommandRequest request = new() { formFile = formFile, Id = id };
            UpdateProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveProductImage(string Id)
        {
            RemoveProductImageCommandRequest request = new RemoveProductImageCommandRequest { Id = Id };
            RemoveProductImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
