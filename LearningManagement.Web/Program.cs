using LearningManagement.Application.Repository;
using LearningManagement.Application.Services;
using LearningManagement.Data;
using LearningManagement.Data.Models;
using LearningManagement.Infrastructure.ImageStorageHelper;
using LearningManagement.Infrastructure.Mapper;
using LearningManagement.Web.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(AcademicMappingProfile).Assembly);

            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                                   throw new InvalidOperationException(
                                       "Connection string 'DefaultConnection' not found.");




            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.Password = new PasswordOptions
                    {
                        RequireDigit = false,
                        RequiredLength = 6,
                        RequiredUniqueChars = 0,
                        RequireLowercase = false,
                        RequireNonAlphanumeric = false,
                        RequireUppercase = false
                    };
                })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //Configure authentication services
            builder.Services.ConfigureApplicationCookie(options => {
                    options.Cookie.Name = "AuthCookie";
                    options.LoginPath = "/Home/Index";
                    options.LogoutPath = "/Auth/Logout";
                    options.AccessDeniedPath = "/Home/Error"; //"/Auth/AccessDenied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    options.SlidingExpiration = true;
                    //options.Events.OnRedirectToLogin = context =>
                    //{
                    //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    //    return Task.CompletedTask;
                    //};
                });


            //Inject Repositories
            builder.Services.AddScoped<IAcademicSessionRepository, AcademicSessionRepository>();
            builder.Services.AddScoped<IInstitutionAdminRepository, InstitutionAdminRepository>();
            builder.Services.AddScoped<IInstitutionClassRepository, InstitutionClassRepository>();
            builder.Services.AddScoped<IInstitutionCourseRepository, InstitutionCourseRepository>();
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IInstitutionRepository, InstitutionRepository>();

            //Inject Services
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAcademicSessionService, AcademicSessionService>();
            builder.Services.AddScoped<IInstitutionClassService, InstitutionClassService>();
            builder.Services.AddScoped<IInstitutionCourseService, InstitutionCourseService>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IInstitutionService, InstitutionService>();


            //Inject others
            builder.Services.AddScoped<IFileStorageHelper, LocalStorageHelper>();

            builder.Services.AddScoped<NotificationHelper>();


            builder.Services.AddHttpContextAccessor();
            var app = builder.Build();

            //for database Migration
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}