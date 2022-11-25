using AutoMapper;
using LibraryWebApi1.Models;

namespace LIbraryWebApi1.AutoMapperProfiles
{
    public class BookAutoMapperProfile:Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}