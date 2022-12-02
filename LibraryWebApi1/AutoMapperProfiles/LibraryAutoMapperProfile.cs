using AutoMapper;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;

namespace LibraryWebApi1.AutoMapperProfiles
{
    public class LibraryAutoMapperProfile:Profile
    {
        public LibraryAutoMapperProfile()
        {
            CreateMap<BaseClass, LibraryDTO>().ReverseMap();
            CreateMap<LibraryDTO, Book>().ReverseMap()
                .AfterMap(((book, dto) => dto.Type = "Book"));
            CreateMap<LibraryDTO, Magazine>().ReverseMap()
                .AfterMap(((magazine, dto) => dto.Type = "Magazine"));
        }  
    }
}