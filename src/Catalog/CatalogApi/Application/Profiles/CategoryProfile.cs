using AutoMapper;
using CatalogApi.Application.Models;
using CatalogApi.Application.Models.Category;
using CatalogApi.Domain.Aggregates.Commands.Category;
using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Queries.Aggregates.Models;
using CatalogApi.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() => MapCreateCategory();

        private void MapCreateCategory()
        {
            CreateMap<Category, CategoryModel>();
            CreateMap<SubCategory, SubCategoriaModel>();

            CreateMap<SubCategoriaModel, SubCategory>().ForMember(d => d.Category, o => o.Ignore());

            CreateMap<CreateCategoryRequest, CreateCategoryCommand>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Image, opt => opt.MapFrom(o => o.Image))
                .ForMember(d => d.SubCategories, opt => opt.MapFrom(o => o.SubCategories));

            CreateMap<CommandResult<Category>, CreateCategoryResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Image, opt => opt.MapFrom(o => o.Image))
                .ForMember(d => d.SubCategories, opt => opt.MapFrom(o => o.SubCategories));

            CreateMap<CommandResult<Category>, UpdateCategoryResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<CommandResult<Category>, DeleteCategoryResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
