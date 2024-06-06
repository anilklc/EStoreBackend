using EStoreBackend.Application.Features.Commands.Prdouct.CreateProduct;
using EStoreBackend.Application.Features.Queries.Product.GetAllProduct;
using EStoreBackend.Application.Features.Queries.Product.GetAllProductAdmin;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommandRequest request)
        {
            //request.FormFile = formFile;
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
