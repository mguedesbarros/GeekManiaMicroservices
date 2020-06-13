using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatalogApi.Application.Models.Category;
using CatalogApi.Application.Services.Interfaces;
using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Queries.Aggregates.Models;
using CatalogApi.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _service;

        public CategoryController(ICategoryAppService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("GetCategories")]
        [ProducesResponseType(typeof(IList<CategoryModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetCategories()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = await _service.GetCategories();
            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = await _service.CreateAsync(request);
                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("Category does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = await _service.UpdateAsync(request);
                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("Category does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.DeleteAsync(id);
                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("Category does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
