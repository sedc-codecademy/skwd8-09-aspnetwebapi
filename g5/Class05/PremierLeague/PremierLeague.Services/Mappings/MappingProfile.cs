using System.Linq;
using AutoMapper;
using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.PresentationLayer.Responses;

namespace PremierLeague.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamResponseModel>()
                .ForMember(dest => dest.City, model => model.MapFrom(m => m.City))
                .ForMember(dest => dest.Country, model => model.MapFrom(m => m.Country))
                .ForMember(dest => dest.CoachName, model => model.MapFrom(m => m.CoachNavigation.FullName))
                .ForMember(dest => dest.PlayerNames, model => model.MapFrom(m => m.Player.Select(p => p.FullName)))
                .ReverseMap();
        }
    }
}
