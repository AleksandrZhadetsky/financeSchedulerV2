using AutoMapper;
using Domain.DTOs;
using Domain.Entities.User;

namespace FinanceSchedulerDemo.MappingProfiles
{
    public class IdentityUserMappingProfile : Profile
    {
        public IdentityUserMappingProfile()
        {
            CreateMap<AppUser, UserDTO>()
                .ForMember(user => user.Id, options => options.MapFrom(identityUser => identityUser.Id))
                .ForMember(user => user.UserName, options => options.MapFrom(identityUser => identityUser.UserName))
                .ForMember(user => user.Email, options => options.MapFrom(identityUser => identityUser.Email))
                .ForMember(user => user.Balance, options => options.MapFrom(identityUser => identityUser.Balance))
                .ReverseMap();
        }
    }
}
