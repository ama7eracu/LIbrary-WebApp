using AutoMapper;
using LibraryWebApi1.Interfaces.Models;
using LibraryWebApi1.Interfaces.Models.DTO;

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