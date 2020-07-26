using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatalogApiReading.Infrastructure.Data;
using CatalogApiReading.Infrastructure.Data.Caching;
using CatalogApiReading.Infrastructure.Data.Caching.CategoryProduct;
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
        const string KEY_CACHE = "categoryProduct";
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
            var key = $"{KEY_CACHE}-{id}";

            var categoryProducts = await _categoryProductRedisRepository.Get<CategoryProduct>(key, (int)RedisBase.Product, true);


            if (categoryProducts != null && categoryProducts.Products.Any())
                return Ok(categoryProducts);
            else
            {
                categoryProducts = await _categoryProductRepository.GetCategoryProductsByDocumentId(id);

                _categoryProductRedisRepository.Set(key, categoryProducts, (int)RedisBase.Product);
            }

            return Ok(categoryProducts);
        }
    }
}
