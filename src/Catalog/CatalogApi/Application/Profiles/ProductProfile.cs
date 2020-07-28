using AutoMapper;
using CatalogApi.Application.Models.Product;
using CatalogApi.Domain.Aggregates.Commands.Product;
using CatalogApi.Domain.Entities;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() => MapCreateProduct();

        private void MapCreateProduct()
        {
            CreateMap<ProductImage, ProductImageModel>();
            CreateMap<ProductImageModel, ProductImage>()
                .ForMember(d => d.ProductId, o => o.Ignore())
                .ForMember(d => d.Product, o => o.Ignore());

            CreateMap<Product, ProductModel>();

            CreateMap<CreateProductRequest, CreateProductCommand>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(o => o.Description))
                .ForMember(d => d.UnityPrice, opt => opt.MapFrom(o => o.UnityPrice))
                .ForMember(d => d.QuantityInStock, opt => opt.MapFrom(o => o.QuantityInStock))
                .ForMember(d => d.Image, opt => opt.MapFrom(o => o.Image))
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(o => o.CategoryId))
                .ForMember(d => d.SubCategoryId, opt => opt.MapFrom(o => o.SubCategoryId))
                .ForMember(d => d.NoveltyId, opt => opt.MapFrom(o => o.NoveltyId))
                .ForMember(d => d.Images, opt => opt.MapFrom(o => o.Images));

            CreateMap<CommandResult<Product>, CreateProductResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<UpdateProductRequest, UpdateProductCommand>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(o => o.Description))
                .ForMember(d => d.UnityPrice, opt => opt.MapFrom(o => o.UnityPrice))
                .ForMember(d => d.QuantityInStock, opt => opt.MapFrom(o => o.QuantityInStock))
                .ForMember(d => d.Image, opt => opt.MapFrom(o => o.Image))
                .ForMember(d => d.CategoryId, opt => opt.MapFrom(o => o.CategoryId))
                .ForMember(d => d.SubCategoryId, opt => opt.MapFrom(o => o.SubCategoryId))
                .ForMember(d => d.NoveltyId, opt => opt.MapFrom(o => o.NoveltyId))
                .ForMember(d => d.Images, opt => opt.MapFrom(o => o.Images));

            CreateMap<CommandResult<Product>, UpdateProductResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<CommandResult<Product>, DeleteProductResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }

    }
}
