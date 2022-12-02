using AutoMapper;
using LibraryWebApi1.Interfaces.Models;
using LibraryWebApi1.Interfaces.Models.DTO;

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