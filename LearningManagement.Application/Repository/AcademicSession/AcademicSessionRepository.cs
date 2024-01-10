using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class AcademicSessionRepository:BaseRepository<AcademicSession>,IAcademicSessionRepository
{
    public AcademicSessionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Result> AcademicSessionAddAsync(int institutionId, AcademicSessionModel model)
    {
        try
        {
            var isAcademicSessionNameExist =
                await this.IsAcademicSessionNameExistAsync(institutionId, model.SessionName);
           
            if (isAcademicSessionNameExist) return Result.Fail($"{model.SessionName} already exist");

            var academicSession = _mapper.Map<AcademicSession>(model);
            academicSession.InstitutionId = institutionId;
            //academicSession.AverageStudentAttendance = model.AverageStudentAttendance;
            //academicSession.AcademicCalendar = model.AcademicCalendar;
            //academicSession.IsActive = model.IsActive;
            //academicSession.SessionDirector = model.SessionDirector;
            //academicSession.SessionTime = model.SessionTime;
            //academicSession.TotalStudentsEnrolled = model.TotalStudentsEnrolled;
            //academicSession.AverageStudentAttendance = model.AverageStudentAttendance;
            //academicSession.AverageStudentPerformance = model.AverageStudentPerformance;
            //academicSession.Achievements = model.Achievements;
            //academicSession.ChallengesFaced = model.ChallengesFaced;
            //academicSession.FutureGoals = model.FutureGoals;

            _context.AcademicSessions.Add(academicSession);
           
            await _context.SaveChangesAsync();
            
            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<AcademicSessionModel>>> AcademicSessionListAsync(int institutionId)
    {
        try
        {
          var academicSessionList = await  _context.AcademicSessions.Where(e=> e.InstitutionId == institutionId)
                .ProjectTo<AcademicSessionModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
          
            return Result.Ok(academicSessionList);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<AcademicSessionModel>> AcademicSessionDetailsAsync(int institutionId, int academicSessionId)
    {

        try
        {
            var academicSession = await _context.AcademicSessions.Where(e => e.InstitutionId == institutionId && e.AcademicSessionId == academicSessionId)
                .ProjectTo<AcademicSessionModel>(_mapper.ConfigurationProvider)
                .FirstAsync();

            return academicSession == null ? Result.Fail("Data not found") : Result.Ok(academicSession);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<bool> IsAcademicSessionNameExistAsync(int institutionId, string name)
    {
        return await _context.AcademicSessions.AnyAsync(e => e.InstitutionId == institutionId && e.SessionName == name);
    }
}