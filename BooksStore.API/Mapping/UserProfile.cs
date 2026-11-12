using AutoMapper;
using BooksStore.Models.DOTs;
using BooksStore.Models.Entities;

namespace BooksStore.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<NewUser, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(u => $"{u.FirstName} {u.LastName}"));
        
    }
}
