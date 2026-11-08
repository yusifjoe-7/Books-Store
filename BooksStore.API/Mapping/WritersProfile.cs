using AutoMapper;
using BooksStore.Models.DOTs;
using BooksStore.Models.Entities;

namespace BooksStore.Mapping;

public class WritersProfile : Profile
{
    public WritersProfile()
    {
       CreateMap<AddWriterRequest, Writer>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        CreateMap<Writer, WriterBookResponse>();
    }
}
