﻿using AutoMapper;
using Domain.Entities.Categories;
using Domain.DTOs;
using Handlers.CategoriesProcessing.Create;
using Handlers.CategoriesProcessing.Update;

namespace FinanceSchedulerDemo.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(model => model.Id, options => options.MapFrom(category => category.Id))
                .ForMember(model => model.Name, options => options.MapFrom(category => category.Name))
                .ForMember(model => model.Description, options => options.MapFrom(category => category.Description))
                .ReverseMap()
                .ForMember(category => category.Id, options => options.MapFrom(model => model.Id))
                .ForMember(category => category.Name, options => options.MapFrom(model => model.Name))
                .ForMember(category => category.Description, options => options.MapFrom(model => model.Description));

            CreateMap<Category, CreateCategoryCommand>()
                .ForMember(command => command.Name, options => options.MapFrom(category => category.Name))
                .ForMember(command => command.Description, options => options.MapFrom(category => category.Description))
                .ReverseMap()
                .ForMember(category =>category.Name, options => options.MapFrom(command => command.Name))
                .ForMember(category => category.Description, options => options.MapFrom(command => command.Description));

            CreateMap<Category, UpdateCategoryCommand>()
                .ForMember(command => command.Id, options => options.MapFrom(category => category.Id))
                .ForMember(command => command.Name, options => options.MapFrom(category => category.Name))
                .ForMember(command => command.Description, options => options.MapFrom(category => category.Description))
                .ReverseMap()
                .ForMember(category => category.Id, options => options.MapFrom(command => command.Id))
                .ForMember(category => category.Name, options => options.MapFrom(command => command.Name))
                .ForMember(category => category.Description, options => options.MapFrom(command => command.Description));
        }
    }
}
