using AutoMapper;
using Domain.DTOs;
using Domain.Entities.Purchases;
using Handlers.PurchasesProcessing.Create;
using Handlers.PurchasesProcessing.Update;

namespace FinanceSchedulerDemo.MappingProfiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<Purchase, PurchaseDTO>()
                .ForMember(model => model.Id, options => options.MapFrom(purchase => purchase.Id))
                .ForMember(model => model.Name, options => options.MapFrom(purchase => purchase.Name))
                .ForMember(model => model.Cost, options => options.MapFrom(purchase => purchase.Cost))
                .ForMember(model => model.Count, options => options.MapFrom(purchase => purchase.Count))
                .ForMember(model => model.CategoryId, options => options.MapFrom(purchase => purchase.CategoryId))
                .ForMember(model => model.CreationDate, options => options.MapFrom(purchase => purchase.CreationDate))
                .ReverseMap()
                .ForMember(purchase => purchase.Id, options => options.MapFrom(model => model.Id))
                .ForMember(purchase => purchase.Name, options => options.MapFrom(model => model.Name))
                .ForMember(purchase => purchase.Cost, options => options.MapFrom(model => model.Cost))
                .ForMember(purchase => purchase.Count, options => options.MapFrom(model => model.Count))
                .ForMember(purchase => purchase.CategoryId, options => options.MapFrom(model => model.CategoryId))
                .ForMember(purchase => purchase.CreationDate, options => options.MapFrom(model => model.CreationDate));

            CreateMap<Purchase, UpdatePurchaseCommand>()
                .ForMember(command => command.Id, options => options.MapFrom(purchase => purchase.Id))
                .ForMember(command => command.Name, options => options.MapFrom(purchase => purchase.Name))
                .ForMember(command => command.Cost, options => options.MapFrom(purchase => purchase.Cost))
                .ForMember(command => command.Count, options => options.MapFrom(purchase => purchase.Count))
                .ForMember(command => command.CategoryId, options => options.MapFrom(purchase => purchase.CategoryId))
                .ReverseMap()
                .ForMember(command => command.Id, options => options.MapFrom(purchase => purchase.Id))
                .ForMember(purchase => purchase.Name, options => options.MapFrom(command => command.Name))
                .ForMember(purchase => purchase.Cost, options => options.MapFrom(command => command.Cost))
                .ForMember(purchase => purchase.Count, options => options.MapFrom(command => command.Count))
                .ForMember(purchase => purchase.CategoryId, options => options.MapFrom(command => command.CategoryId));

            CreateMap<Purchase, CreatePurchaseCommand>()
                .ForMember(command => command.Name, options => options.MapFrom(purchase => purchase.Name))
                .ForMember(command => command.Cost, options => options.MapFrom(purchase => purchase.Cost))
                .ForMember(command => command.Count, options => options.MapFrom(purchase => purchase.Count))
                .ForMember(command => command.CategoryId, options => options.MapFrom(purchase => purchase.CategoryId))
                .ForMember(model => model.CreatedById, options => options.MapFrom(purchase => purchase.AppUserId))
                .ReverseMap()
                .ForMember(purchase => purchase.Name, options => options.MapFrom(command => command.Name))
                .ForMember(purchase => purchase.Cost, options => options.MapFrom(command => command.Cost))
                .ForMember(purchase => purchase.Count, options => options.MapFrom(command => command.Count))
                .ForMember(purchase => purchase.CategoryId, options => options.MapFrom(command => command.CategoryId))
                .ForMember(purchase => purchase.AppUserId, options => options.MapFrom(command => command.CreatedById));
        }
    }
}
