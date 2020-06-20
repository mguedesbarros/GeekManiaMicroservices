using CatalogApi.Application.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Services.Interfaces
{
    public interface IProductAppService
    {
        Task<CreateProductResponse> CreateAsync(CreateProductRequest request);
        Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request);
        Task<DeleteProductResponse> DeleteAsync(Guid id);
    }
}
