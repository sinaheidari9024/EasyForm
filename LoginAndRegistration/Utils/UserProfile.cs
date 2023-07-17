using AutoMapper;
using EasyForm.Entities;
using EasyForm.ViewModel;

namespace EasyForm.Utils
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationPart, ApplicationPartVm>()
                .ForMember(dest => dest.ApplicationId,
            opt => opt.MapFrom(src => src.Application.Id))
                .ForMember(dest =>dest.ApplicationName,
            opt => opt.MapFrom(src => src.Application.Title));

            CreateMap<ApplicationPart, CreateApplicationPartVm>();
        }

    }
}
