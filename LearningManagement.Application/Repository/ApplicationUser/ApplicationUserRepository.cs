using AutoMapper;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class ApplicationUserRepository:BaseRepository<ApplicationUser>, IApplicationUserRepository
{
    public ApplicationUserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {

    }

    public async Task<int?> GetInstitutionByUserNameAsync(string userName)
    {
      var appUser = await _context.ApplicationUsers.FirstOrDefaultAsync(e => e.UserName == userName);
      return appUser?.InstitutionId;
    }

    public async Task<string?> GetApplicationUserIdByUserNameAsync(string userName)
    {
        var appUser = await _context.ApplicationUsers.FirstOrDefaultAsync(e => e.UserName == userName);
        return appUser?.Id;
    }
}