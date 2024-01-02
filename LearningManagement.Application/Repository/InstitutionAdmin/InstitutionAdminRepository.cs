using AutoMapper;
using FluentResults;
using LearningManagement.Data.ViewModels;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class InstitutionAdminRepository : BaseRepository<InstitutionAdmin>, IInstitutionAdminRepository
{
    public InstitutionAdminRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Result> InstitutionAdminAddAsync(InstitutionAdminCreateModel model)
    {
        try
        {
            var isAdminExist = await IsAdminExistAsync(model.ApplicationUserId);

            if (isAdminExist) return Result.Fail($"ApplicationUserId already exist");

            var institutionAdmin = _mapper.Map<InstitutionAdmin>(model);

            _context.InstitutionAdmins.Add(institutionAdmin);

            await _context.SaveChangesAsync();

            return Result.Ok();
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<AdminViewModel>> InstitutionAdminInfoAsync(string userName)
    {
        try
        {
            var appUser = await _context.ApplicationUsers.Include(u => u.InstitutionAdmin).FirstOrDefaultAsync(e => e.UserName == userName);

            if (appUser == null) return Result.Fail($"user not found");

            var adminViewModel = _mapper.Map<AdminViewModel>(appUser);

            return Result.Ok(adminViewModel);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<AdminViewModel>> UpdateInstitutionAdminInfoAsync(string userName, AdminViewModel model)
    {
        try
        {
            var appUser = await _context.ApplicationUsers.Include(u => u.InstitutionAdmin).FirstOrDefaultAsync(e => e.UserName == userName);

            if (appUser == null) return Result.Fail($"user not found");

            var institutionAdmin = appUser.InstitutionAdmin;
            institutionAdmin.FirstName = model.FirstName;
            institutionAdmin.LastName = model.LastName;
 
            _context.InstitutionAdmins.Update(institutionAdmin);

            await _context.SaveChangesAsync();
            
            var adminViewModel = _mapper.Map<AdminViewModel>(appUser);

            return Result.Ok(adminViewModel);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<bool> IsAdminExistAsync(string applicationUserId)
    {
        return await _context.InstitutionAdmins.AnyAsync(e => e.ApplicationUserId == applicationUserId);
    }
}