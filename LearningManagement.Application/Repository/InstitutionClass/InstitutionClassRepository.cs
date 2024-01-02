using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class InstitutionClassRepository:BaseRepository<InstitutionClass>,IInstitutionClassRepository
{
    public InstitutionClassRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Result> ClassAddAsync(int institutionId, InstitutionClassModel model)
    {
        try
        {
            var isClassNameExist =
                await this.IsClassNameExistAsync(institutionId, model.ClassName);

            if (isClassNameExist) return Result.Fail($"{model.ClassName} already exist");

            var institutionClass = _mapper.Map<InstitutionClass>(model);
            institutionClass.InstitutionId = institutionId;
            _context.InstitutionClasses.Add(institutionClass);

            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<InstitutionClassModel>>> ClassListAsync(int institutionId)
    {
        try
        {
            var classList = await _context.InstitutionClasses.Where(e => e.InstitutionId == institutionId)
                  .ProjectTo<InstitutionClassModel>(_mapper.ConfigurationProvider)
                  .ToListAsync();

            return Result.Ok(classList);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionClassModel>> ClassDetailsAsync(int institutionId, int ClassId)
    {

        try
        {
            var classModel = await _context.InstitutionClasses.Where(e => e.InstitutionId == institutionId && e.InstitutionClassId == ClassId)
                .ProjectTo<InstitutionClassModel>(_mapper.ConfigurationProvider)
                .FirstAsync();

            return classModel == null ? Result.Fail("Data not found") : Result.Ok(classModel);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<bool> IsClassNameExistAsync(int institutionId, string name)
    {
        return await _context.InstitutionClasses.AnyAsync(e => e.InstitutionId == institutionId && e.ClassName == name);
    }
}