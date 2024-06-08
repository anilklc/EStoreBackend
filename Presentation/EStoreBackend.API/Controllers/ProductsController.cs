using EStoreBackend.Application.Features.Commands.Prdouct.CreateProduct;
using EStoreBackend.Application.Features.Commands.Prdouct.RemoveProduct;
using EStoreBackend.Application.Features.Commands.Prdouct.UpdateProduct;
using EStoreBackend.Application.Features.Commands.Prdouct.UpdateProductCoverImage;
using EStoreBackend.Application.Features.Queries.Product.GetAllProduct;
using EStoreBackend.Application.Features.Queries.Product.GetAllProductAdmin;
using EStoreBackend.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProducts() 
        {
            GetAllProductQueryResponse response = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(response);
        
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductsAdmin()
        {
            GetAllProductAdminQueryResponse response = await _mediator.Send(new GetAllProductAdminQueryRequest());
            return Ok(response);

        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommandRequest request,IFormFile formFile)
        {
            request.FormFile = formFile;
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCoverProductImage(IFormFile formFile, string id)
        {
            UpdateProductCoverImageCommandRequest request = new() { formFile = formFile, Id = id };
            UpdateProductCoverImageCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveProduct(string Id)
        {
            RemoveProductCommandRequest request = new RemoveProductCommandRequest { Id = Id };
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
