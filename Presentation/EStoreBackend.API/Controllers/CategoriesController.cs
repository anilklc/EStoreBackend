using EStoreBackend.Application.Features.Commands.Category.CreateCategory;
using EStoreBackend.Application.Features.Commands.Category.RemoveCategory;
using EStoreBackend.Application.Features.Commands.Category.UpdateCategory;
using EStoreBackend.Application.Features.Queries.Category.GetAllCategory;
using EStoreBackend.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute] GetByIdCategoryQueryRequest request)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveCategory(string Id)
        {
            RemoveCategoryCommandRequest request = new RemoveCategoryCommandRequest { Id = Id };
            RemoveCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
