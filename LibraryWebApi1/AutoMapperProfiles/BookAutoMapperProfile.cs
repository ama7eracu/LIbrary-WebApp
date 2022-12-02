using AutoMapper;
using LibraryWebApi1.Interfaces.Models;
using LibraryWebApi1.Interfaces.Models.DTO;

namespace LibraryWebApi1.AutoMapperProfiles
{
    public class BookAutoMapperProfile:Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}