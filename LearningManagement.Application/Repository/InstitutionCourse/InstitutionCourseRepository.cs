using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class InstitutionCourseRepository:BaseRepository<InstitutionCourse>, IInstitutionCourseRepository
{
    public InstitutionCourseRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Result> CourseAddAsync(int institutionId, InstitutionCourseModel model)
    {
        try
        {
            var isCourseNameExist =
                await this.IsCourseNameExistAsync(institutionId, model.CourseName);

            if (isCourseNameExist) return Result.Fail($"{model.CourseName} already exist");

            var institutionCourse = _mapper.Map<InstitutionCourse>(model);
            institutionCourse.InstitutionId = institutionId;
            _context.InstitutionCourses.Add(institutionCourse);

            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<InstitutionCourseModel>>> CourseListAsync(int institutionId)
    {
        try
        {
            var CourseList = await _context.InstitutionCourses.Where(e => e.InstitutionId == institutionId)
                  .ProjectTo<InstitutionCourseModel>(_mapper.ConfigurationProvider)
                  .ToListAsync();

            return Result.Ok(CourseList);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionCourseModel>> CourseDetailsAsync(int institutionId, int CourseId)
    {

        try
        {
            var CourseModel = await _context.InstitutionCourses.Where(e => e.InstitutionId == institutionId && e.InstitutionCourseId == CourseId)
                .ProjectTo<InstitutionCourseModel>(_mapper.ConfigurationProvider)
                .FirstAsync();

            return CourseModel == null ? Result.Fail("Data not found") : Result.Ok(CourseModel);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<bool> IsCourseNameExistAsync(int institutionId, string name)
    {
        return await _context.InstitutionCourses.AnyAsync(e => e.InstitutionId == institutionId && e.CourseName == name);
    }
}