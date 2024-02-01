﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using LearningManagement.Data.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Application.Repository;

public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
{
    public InstitutionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {

    }

    public async Task<Result<Institution>> CreateInstitutionInfoAsync(InstitutionViewModel model)
    {
        try
        {
            var createInstitution = await _context.AddAsync(_mapper.Map<Institution>(model));
            var institution = _mapper.Map<Institution>(createInstitution.Entity);
            await _context.SaveChangesAsync();
            return Result.Ok(institution);
        }
        catch (Exception ex)
        {
            return Result.Fail<Institution>(ex.Message);
        }
    }



    public async Task<Result<InstitutionViewModel>> GetInstitutionInfoAsync(int institutionId)
    {
        try
        {
            var institution = await _context.Institutions.FindAsync(institutionId);

            if (institution == null) return Result.Fail($"Institution not found");

            var institutionViewModel = _mapper.Map<InstitutionViewModel>(institution);

            return Result.Ok(institutionViewModel);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<List<InstitutionViewModel>>> InstitutionListAsync()
    {

        try
        {
            var institutionViewModels = await _context.Institutions
                .ProjectTo<InstitutionViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(institutionViewModels);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }

    public async Task<Result<InstitutionViewModel>> UpdateInstitutionInfoAsync(int institutionId, InstitutionViewModel model)
    {
        try
        {
            var institution = await _context.Institutions.FindAsync(institutionId);

            if (institution == null) return Result.Fail($"Institution not found");


            institution.InstitutionName = model.InstitutionName;
            if (!string.IsNullOrEmpty(model.InstitutionLogoName)) institution.InstitutionLogoName = model.InstitutionLogoName;
            institution.ContactNumber = model.ContactNumber;
            institution.Email = model.Email;
            institution.Website = model.Website;
            institution.BrandingTagLine = model.BrandingTagLine;
            institution.Address = model.Address;
            institution.FoundedDate = model.FoundedDate;
            institution.Founder = model.Founder;
            institution.MissionStatement = model.MissionStatement;
            institution.VisionStatement = model.VisionStatement;
            institution.Accreditation = model.Accreditation;
            institution.Affiliation = model.Affiliation;
            institution.TotalStudents = model.TotalStudents;
            institution.TotalTeachers = model.TotalTeachers;
            institution.TotalCourses = model.TotalCourses;
            institution.CampusFacilities = model.CampusFacilities;
            institution.SocialMediaLinks = model.SocialMediaLinks;
            institution.AdmissionProcedure = model.AdmissionProcedure;
            institution.PrincipalName = model.PrincipalName;
            institution.PrincipalEmail = model.PrincipalEmail;
            institution.PrincipalPhone  = model.PrincipalPhone;


            _context.Institutions.Update(institution);

            await _context.SaveChangesAsync();

            return await GetInstitutionInfoAsync(institution.InstitutionId);
        }
        catch (SqlException e)
        {
            return Result.Fail(e.InnerException?.Message ?? e.Message);
        }
    }
}