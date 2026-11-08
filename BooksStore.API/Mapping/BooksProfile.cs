using AutoMapper;
using BooksStore.Models.DOTs;
using BooksStore.Models.Entities;

namespace BooksStore.Mapping;

public class BooksProfile : Profile
{
    public BooksProfile()
    {
       CreateMap<Book, BookResponse>();
        CreateMap<Tag, TagsResponse>();
    }
}
