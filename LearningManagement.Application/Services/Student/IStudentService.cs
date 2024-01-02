using FluentResults;
using LearningManagement.Data.ViewModels;

namespace LearningManagement.Application.Services;

public interface IStudentService
{
    Task<Result<List<StudentViewModel>>> StudentListAsync();
    Task<Result<StudentModel>> StudentDetailsAsync( int studentId);
}