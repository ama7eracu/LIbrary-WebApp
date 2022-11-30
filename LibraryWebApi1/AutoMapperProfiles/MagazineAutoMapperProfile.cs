using AutoMapper;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;

namespace LibraryWebApi1.AutoMapperProfiles
{
    public class MagazineAutoMapperProfile:Profile
    {
        public MagazineAutoMapperProfile()
        {
            CreateMap<MagazineDto, Magazine>().ReverseMap();
        }
    }
}