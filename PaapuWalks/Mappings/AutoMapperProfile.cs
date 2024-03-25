using AutoMapper;
using PaapuWalks.Models.Domain;
using PaapuWalks.Models.DTO;

namespace PaapuWalks.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region,RegionDto>().ReverseMap();

            CreateMap<Region,CreateRegionDto>().ReverseMap();

            CreateMap<Region,UpdateRegionDto>().ReverseMap();

            CreateMap<Walk, CreateWalkDto>().ReverseMap();

            CreateMap<Walk,WalkDto>().ReverseMap();
            

            
        }
    }
}
