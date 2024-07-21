using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.Prdouct.CreateProduct;
using EStoreBackend.Application.Features.Commands.Prdouct.RemoveProduct;
using EStoreBackend.Application.Features.Commands.Prdouct.UpdateProduct;
using EStoreBackend.Application.Features.Commands.Prdouct.UpdateProductCoverImage;
using EStoreBackend.Application.Features.Queries.Product.GetAllProduct;
using EStoreBackend.Application.Features.Queries.Product.GetAllProductAdmin;
using EStoreBackend.Application.Features.Queries.Product.GetAllProductByFilter;
using EStoreBackend.Application.Features.Queries.Product.GetByIdProduct;
using EStoreBackend.Application.Features.Queries.Product.GetProductDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;

        public ProductsController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Product"])]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest request) 
        {
            GetAllProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProductsByFilter([FromQuery] GetAllProductByFilterQueryRequest request)
        {
            GetAllProductByFilterQueryResponse response = await _mediator.Send(request);
            return Ok(response);

        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Product"])]
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductDetail([FromQuery] GetProductDetailQueryRequest request)
        {
            GetProductDetailQueryRespnose response = await _mediator.Send(request);
            return Ok(response);

        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommandRequest request,IFormFile formFile)
        {
            request.FormFile = formFile;
            CreateProductCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Product");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCoverProductImage(IFormFile formFile, string id)
        {
            UpdateProductCoverImageCommandRequest request = new() { formFile = formFile, Id = id };
            UpdateProductCoverImageCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Product");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Product");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveProduct(string Id)
        {
            RemoveProductCommandRequest request = new RemoveProductCommandRequest { Id = Id };
            RemoveProductCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Product");
            return Ok(response);
        }
    }
}
