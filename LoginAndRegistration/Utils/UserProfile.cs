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
                .ForMember(dest => dest.ApplicationSpanishName,
            opt => opt.MapFrom(src => src.Application.SpanishTitle))
                .ForMember(dest =>dest.ApplicationName,
            opt => opt.MapFrom(src => src.Application.Title));

            CreateMap<ApplicationPart, CreateApplicationPartVm>();

            CreateMap<Question, QuestionVm>()
                .ForMember(dest => dest.PartId,
            opt => opt.MapFrom(src => src.Part.Id))
                .ForMember(dest => dest.PartName,
            opt => opt.MapFrom(src => src.Part.Title))
                .ForMember(dest => dest.SpanishPartName,
            opt => opt.MapFrom(src => src.Part.SpanishTitle))
                .ForMember(dest => dest.SpanishApplicationName,
            opt => opt.MapFrom(src => src.Part.Application.SpanishTitle))
                .ForMember(dest => dest.ApplicationName,
            opt => opt.MapFrom(src => src.Part.Application.Title));

            CreateMap<Question, CreateQuestionVm>();

            CreateMap<QuestionItem, GetQuestionItemVm>()
                .ForMember(dest => dest.QuestionSpanishText,
            opt => opt.MapFrom(src => src.Question.SpanishText))
                .ForMember(dest => dest.QuestionText,
            opt => opt.MapFrom(src => src.Question.Text));

            CreateMap<AnswerVm, Answer>();
            CreateMap<ApplicationVm, Application>();
            CreateMap<Application, ApplicationVm>();
        }

    }
}
