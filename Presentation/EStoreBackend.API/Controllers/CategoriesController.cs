﻿using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.Category.CreateCategory;
using EStoreBackend.Application.Features.Commands.Category.RemoveCategory;
using EStoreBackend.Application.Features.Commands.Category.UpdateCategory;
using EStoreBackend.Application.Features.Queries.Category.GetAllCategory;
using EStoreBackend.Application.Features.Queries.Category.GetAllPopularCategory;
using EStoreBackend.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;

        public CategoriesController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Category"])]
        public async Task<IActionResult> GetAllCategories()
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute] GetByIdCategoryQueryRequest request)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPopularCategory()
        {
            GetAllPopularCategoryQueryResponse response = await _mediator.Send(new GetAllPopularCategoryQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Category");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Category");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveCategory(string Id)
        {
            RemoveCategoryCommandRequest request = new RemoveCategoryCommandRequest { Id = Id };
            RemoveCategoryCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Category");
            return Ok(response);
        }
    }
}
