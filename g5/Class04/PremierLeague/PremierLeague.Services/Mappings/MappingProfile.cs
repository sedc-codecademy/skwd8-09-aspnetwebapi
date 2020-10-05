using AutoMapper;
using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.PresentationLayer.Responses;

namespace PremierLeague.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamResponseModel>().ForMember(dest => dest.City, model => model.MapFrom(m => m.City)).ReverseMap();
            CreateMap<Team, TeamResponseModel>().ForMember(dest => dest.Country, model => model.MapFrom(m => m.Country)).ReverseMap();
        }
    }
}
