using AutoMapper;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;

namespace LibraryWebApi1.AutoMapperProfiles
{
    public class BookAutoMapperProfile:Profile
    {
        public BookAutoMapperProfile()
        {
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}