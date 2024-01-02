using FluentResults;
using LearningManagement.Data.Models;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Repository;

public interface IStudentRepository:IBaseRepository<InstitutionStudent>
{
    Task<Result> StudentAddAsync(int institutionId, string applicationUserId, StudentModel model);
    Task<Result<List<StudentViewModel>>> StudentListAsync(int institutionId);
    Task<Result<StudentModel>> StudentDetailsAsync(int institutionId, int studentId);
    Task<bool> IsStudentEmailExistAsync(int institutionId, string email);
}