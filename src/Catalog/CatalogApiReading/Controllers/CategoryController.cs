using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatalogApiReading.Infrastructure.Data.Category;
using CatalogApiReading.Infrastructure.Data.CategoryProduct;
using CatalogApiReading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CatalogApiReading.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly ICategoryRedisRepository _categoryRedis;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryProductRepository categoryProductRepository, 
                                  ICategoryRedisRepository categoryRedis,
                                  ILogger<CategoryController> logger)
        {
            _categoryProductRepository = categoryProductRepository ?? throw new ArgumentNullException(nameof(categoryProductRepository));
            _categoryRedis = categoryRedis ?? throw new ArgumentNullException(nameof(categoryRedis));
            _logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(typeof(IList<Category>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var categories = await _categoryRedis.GetCategories();

                if (!categories.Any())
                {
                    var categoryProducts = await _categoryProductRepository.GetAll();

                    categories = categoryProducts.GroupBy(g => g.Name)
                                                     .Select(s => new Category
                                                     {
                                                         Id = s.FirstOrDefault().Id,
                                                         Name = s.FirstOrDefault().Name
                                                     }).ToList();

                    if (categories.Any())
                        _categoryRedis.Delete();

                    _categoryRedis.Add(categories);
                }

                return Ok(categories);
            }
            catch(Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return BadRequest();
            }
            
        }
    }
}
