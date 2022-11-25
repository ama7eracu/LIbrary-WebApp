using AutoMapper;
using LibraryWebApi1.Models;

namespace LIbraryWebApi1.AutoMapperProfiles
{
    public class MagazineAutoMapperProfile:Profile
    {
        public MagazineAutoMapperProfile()
        {
            CreateMap<MagazineDto, Magazine>().ReverseMap();
        }
    }
}