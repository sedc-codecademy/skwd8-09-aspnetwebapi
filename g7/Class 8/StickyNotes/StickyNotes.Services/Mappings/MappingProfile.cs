using AutoMapper;
using StickyNotes.DataAccess.Domain;
using StickyNotes.PresentationLayer.Responses;

namespace StickyNotes.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetUserResponse, User>()
                .ForMember(u => u.CreatedOn, src => src.MapFrom(uvm => uvm.CreatedOn))
                .ForMember(u => u.DeletedOn, src => src.MapFrom(uvm => uvm.DeletedOn))
                .ForMember(u => u.FirstName, src => src.MapFrom(uvm => uvm.FirstName))
                .ForMember(u => u.LastName, src => src.MapFrom(uvm => uvm.LastName))
                .ForMember(u => u.Username, src => src.MapFrom(uvm => uvm.Username))
                .ForMember(u => u.Password, src => src.MapFrom(uvm => uvm.Password))
                .ForMember(u => u.Notes, src => src.MapFrom(uvm => uvm.Notes))
                .ForMember(u => u.Id, src => src.Ignore())
                .ReverseMap();

            CreateMap<GetNoteResponse, Note>()
               .ForMember(n => n.CreatedOn, src => src.MapFrom(uvm => uvm.CreatedOn))
               .ForMember(n => n.DeletedOn, src => src.MapFrom(uvm => uvm.DeletedOn))
               .ForMember(n => n.Title, src => src.MapFrom(uvm => uvm.Title))
               .ForMember(n => n.Text, src => src.MapFrom(uvm => uvm.Text))
               .ForMember(n => n.Id, src => src.Ignore())
               .ReverseMap();
        }
    }
}
