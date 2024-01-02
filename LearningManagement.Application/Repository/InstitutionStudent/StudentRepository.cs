using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using LearningManagement.Data.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class StudentRepository:BaseRepository<InstitutionStudent>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Result> StudentAddAsync(int institutionId, string applicationUserId, StudentModel model)
    {
        try
        {
            var emailExistAsync =
                await this.IsStudentEmailExistAsync(institutionId, model.Email);

            if (emailExistAsync) return Result.Fail($"{model.Email} already exist");

            var institutionStudent = _mapper.Map<InstitutionStudent>(model);
            institutionStudent.ApplicationUserId = applicationUserId;
            institutionStudent.InstitutionId = institutionId;

            var studentInClass = new StudentInClass
            {
                InstitutionId = institutionId,
                InstitutionStudent = institutionStudent,
                AcademicSessionId = model.AcademicSessionId,
                InstitutionClassId = model.InstitutionClassId,
            };
            _context.StudentInClasses.Add(studentInClass);

            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<StudentViewModel>>> StudentListAsync(int institutionId)
    {
        try
        {
            var teacherModels = await _context.StudentInClasses
                .Include(e=> e.InstitutionStudent)
                .Include(e=> e.InstitutionStudent)
                .Include(e=> e.AcademicSession)
                .Where(e => e.InstitutionId == institutionId)
                .ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(teacherModels);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public Task<Result<StudentModel>> StudentDetailsAsync(int institutionId, int studentId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsStudentEmailExistAsync(int institutionId, string email)
    {
        return await _context.InstitutionStudents.AnyAsync(e => e.InstitutionId == institutionId && e.Email == email);
    }
}