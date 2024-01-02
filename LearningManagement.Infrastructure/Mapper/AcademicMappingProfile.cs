using AutoMapper;
using LearningManagement.Data;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data.Models;

namespace LearningManagement.Infrastructure.Mapper;

public class AcademicMappingProfile: Profile
{
    public AcademicMappingProfile()
    {
        CreateMap<AcademicSession, AcademicSessionModel>().ReverseMap();
        CreateMap<InstitutionClassModel, InstitutionClass>().ReverseMap();
        CreateMap<InstitutionCourseModel, InstitutionCourse>().ReverseMap();
        CreateMap<TeacherWiseCourse, TeacherAssignCourseModel>().ReverseMap();
        CreateMap<StudentInClass, StudentViewModel>()
            .ForMember(d => d.FirstName, opt => opt.MapFrom(c => c.InstitutionStudent!.FirstName))
            .ForMember(d => d.LastName, opt => opt.MapFrom(c => c.InstitutionStudent!.LastName))
            .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.InstitutionStudent!.FullName))
            .ForMember(d => d.FatherName, opt => opt.MapFrom(c => c.InstitutionStudent!.FatherName))
            .ForMember(d => d.MotherName, opt => opt.MapFrom(c => c.InstitutionStudent!.MotherName))
            .ForMember(d => d.AdmissionDate, opt => opt.MapFrom(c => c.InstitutionStudent!.AdmissionDate))
            .ForMember(d => d.AdmissionNumber, opt => opt.MapFrom(c => c.InstitutionStudent!.AdmissionNumber))
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(c => c.InstitutionStudent!.BirthDate))
            .ForMember(d => d.BloodGroup, opt => opt.MapFrom(c => c.InstitutionStudent!.BloodGroup))
            .ForMember(d => d.ClassName, opt => opt.MapFrom(c => c.InstitutionClass!.ClassName))
            .ForMember(d => d.SessionName, opt => opt.MapFrom(c => c.AcademicSession!.SessionName))
            .ForMember(d => d.ImageFileName, opt => opt.MapFrom(c => c.InstitutionStudent!.ImageFileName))
            .ForMember(d => d.Phone, opt => opt.MapFrom(c => c.InstitutionStudent!.Phone))
            .ForMember(d => d.Email, opt => opt.MapFrom(c => c.InstitutionStudent!.Email))
            .ForMember(d => d.Gender, opt => opt.MapFrom(c => c.InstitutionStudent!.Gender))
            .ForMember(d => d.Religion, opt => opt.MapFrom(c => c.InstitutionStudent!.Religion))
            ;


        CreateMap<TeacherWiseCourse, TeacherCourseViewModel>()
            .ForMember(d => d.FullName, opt => opt.MapFrom(c => c.InstitutionTeacher!.FullName))
            .ForMember(d => d.ImageFileName, opt => opt.MapFrom(c => c.InstitutionTeacher!.ImageFileName))
            .ForMember(d => d.ClassName, opt => opt.MapFrom(c => c.InstitutionClass!.ClassName))
            .ForMember(d => d.CourseName, opt => opt.MapFrom(c => c.InstitutionCourse!.CourseName))
            ;

        CreateMap<InstitutionViewModel, Institution>().ReverseMap();
    }
}