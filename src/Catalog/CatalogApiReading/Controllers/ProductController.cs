using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.CategoryProduct;
using CatalogApiReading.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatalogApiReading.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICategoryProductRedisRepository _categoryProductRedisRepository;
        private readonly ICategoryProductRepository _categoryProductRepository;

        public ProductController(ICategoryProductRedisRepository categoryProductRedisRepository, 
            ICategoryProductRepository categoryProductRepository)
        {
            _categoryProductRedisRepository = categoryProductRedisRepository ?? throw new ArgumentNullException(nameof(categoryProductRedisRepository));
            _categoryProductRepository = categoryProductRepository ?? throw new ArgumentNullException(nameof(categoryProductRepository));
        }

        [HttpGet]
        [Route("GetCategoryProductsByDocumentId/{id}")]
        [ProducesResponseType(typeof(CategoryProduct), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCategoryProductsByDocumentId(Guid id)
        {
            var categoryProducts = await _categoryProductRedisRepository.GetCategoryProductsByDocumentId(id);

            if (!categoryProducts.Products.Any())
            {
                categoryProducts = await _categoryProductRepository.GetCategoryProductsByDocumentId(id);

                _categoryProductRedisRepository.Add(categoryProducts);
            }

            return Ok(categoryProducts);
        }
    }
}
