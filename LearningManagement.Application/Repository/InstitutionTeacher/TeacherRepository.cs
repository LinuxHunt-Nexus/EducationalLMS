using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class TeacherRepository:BaseRepository<InstitutionTeacher>,ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Result> TeacherAddAsync(int institutionId, string applicationUserId, TeacherModel model)
    {
        try
        {
            var isCourseNameExist =
                await this.IsTeacherEmailExistAsync(institutionId, model.Email);

            if (isCourseNameExist) return Result.Fail($"{model.Email} already exist");

            var institutionTeacher = _mapper.Map<InstitutionTeacher>(model);
            institutionTeacher.ApplicationUserId = applicationUserId;
            institutionTeacher.InstitutionId = institutionId;
            institutionTeacher.EduQualification = model.EducationQualification?.Split(", ").ToList();
            institutionTeacher.ExamPassYear = model.ExamminationPassYear?.Split(", ").ToList();
            institutionTeacher.DegreeResult = model.DegreePassResult?.Split(", ").ToList();
            _context.InstitutionTeachers.Add(institutionTeacher);

            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result> TeacherAssignCourseAsync(int institutionId, TeacherAssignCourseModel model)
    {
        try
        {
            var teacher = await _context.InstitutionTeachers.Where(e => e.InstitutionTeacherId == model.InstitutionTeacherId && e.InstitutionId == institutionId)
                .FirstAsync();

            if (teacher == null) return Result.Fail($"Teacher not valid");

            var teacherWiseCourse = _mapper.Map<TeacherWiseCourse>(model);
            teacherWiseCourse.InstitutionId = institutionId;

            var isAlreadyAssign = await _context.TeacherWiseCourses.AnyAsync(e =>
                e.InstitutionTeacherId == teacherWiseCourse.InstitutionTeacherId &&
                e.InstitutionClassId == teacherWiseCourse.InstitutionClassId &&
                e.InstitutionCourseId == teacherWiseCourse.InstitutionCourseId);

            if(isAlreadyAssign) return Result.Fail("Already Assign");

            _context.TeacherWiseCourses.Add(teacherWiseCourse);

            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<TeacherModel>>> TeacherListAsync(int institutionId)
    {
        try
        {
            var teacherModels = await _context.InstitutionTeachers.Where(e => e.InstitutionId == institutionId)
                .ProjectTo<TeacherModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(teacherModels);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<TeacherCourseViewModel>>> TeacherAssignCourseListAsync(int institutionId)
    {
        try
        {
            var teacherModels = await _context.TeacherWiseCourses.Where(e => e.InstitutionId == institutionId)
                .ProjectTo<TeacherCourseViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(teacherModels);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<TeacherModel>> TeacherDetailsAsync(int institutionId, int teacherId)
    {
        try
        {
            var teacherModel = await _context.InstitutionTeachers.Where(e => e.InstitutionId == institutionId && e.InstitutionTeacherId == teacherId)
                .ProjectTo<TeacherModel>(_mapper.ConfigurationProvider)
                .FirstAsync();

            return teacherModel == null ? Result.Fail("Data not found") : Result.Ok(teacherModel);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<bool> IsTeacherEmailExistAsync(int institutionId, string email)
    {
        return await _context.InstitutionTeachers.AnyAsync(e => e.InstitutionId == institutionId && e.Email == email);
    }
}