using AutoMapper;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;
using LearningManagement.Data;

namespace LearningManagement.Infrastructure.Mapper;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<InstitutionAdminCreateModel, InstitutionAdmin>().ReverseMap();
        CreateMap<ApplicationUser, AdminViewModel>()
            .ForMember(d => d.FirstName, opt => opt.MapFrom(c => c.InstitutionAdmin!.FirstName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(c => c.InstitutionAdmin!.LastName));

        CreateMap<InstitutionStudent, StudentModel>().ReverseMap();
        CreateMap<InstitutionTeacher, TeacherModel>().ReverseMap();
        CreateMap<AcademicSessionModel, AcademicSession>().ReverseMap();
        CreateMap<Institution, InstitutionViewModel>();
        CreateMap<InstitutionViewModel, Institution>();

    }
}