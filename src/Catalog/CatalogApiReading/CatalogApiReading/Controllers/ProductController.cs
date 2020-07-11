using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CatalogApiReading.Infrastructure.Data.Product;
using CatalogApiReading.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatalogApiReading.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProducRedisRepository _productRedisRepository;
        private readonly IProductRepository _productRepository;

        public ProductController(IProducRedisRepository producRepository, 
            IProductRepository productRepository)
        {
            _productRedisRepository = producRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get()
        {
            var product = await _productRedisRepository.Get();


            return Ok(product);
        }

        //[HttpGet]
        //[Route("GetProductSubCategory/{id}")]
        //[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> GetProductSubCategory(Guid id)
        //{
        //    var items = await _productRedisRepository.GetAllProducts();

        //    if (!items.Any())
        //        return NotFound("Product SubCategory does not exist.");

        //    return Ok(items);
        //}

        [HttpGet]
        [Route("GetProductCategory")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductCategory(Guid IdCategoria, Guid IdSubCategoria)
        {
            var items = await _productRedisRepository.GetProducts(IdCategoria, IdSubCategoria);

            if (!items.Any())
            {
                var builder = Builders<Product>.Filter;
                var filter = builder.Eq(n => n.Id, IdCategoria) & builder.Lt(n => n.SubCategory.Id, IdSubCategoria);

                items = await _productRepository.GetByFilter(filter);

                //if (!items.Any())
                //{
                //    _productRedisRepository.AddProducts(items, IdCategoria, IdSubCategoria);

                //    return Ok(items);
                //}
            }
            
            return NotFound("No items found.");
        }
    }
}
