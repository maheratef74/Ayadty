using System.Globalization;
using System.Resources;
using Ayadty.Data;
using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using BusinessLogicLayer.Services.Prescription;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Generic;
using DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Repositories.Prescription;
using DataAccessLayer.Repositories.Treatment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using presentationLayer.Controllers;
using presentationLayer.Middlewares;
using presentationLayer.Validation;


namespace presentationLayer;

public class Program
{
    public static  async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region DataBase Config
        
        var connectionString = builder.Configuration.GetConnectionString("Ayadty");
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        });
        #endregion

        #region Register service in container

        builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        builder.Services.AddScoped<IAppointmentService, AppointmentService>();
        
        builder.Services.AddScoped<IPatientRepository, PatientRepository>();
        builder.Services.AddScoped<IPatientService, PatientService>();
        
        builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
        builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
        
        builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        
        builder.Services.AddScoped<RoleSeeder>();
        

       // builder.Services.AddScoped<IGenericRepository<T>, GenericRepository<T>>();
       // builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        #endregion

        #region Add Identity services
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;            // No digit required
                options.Password.RequiredLength = 6;              // Minimum length of 6
                options.Password.RequireNonAlphanumeric = false;  // No special character required
                options.Password.RequireUppercase = false;        // No uppercase letter required
                options.Password.RequireLowercase = false;        // No lowercase letter required
                options.Password.RequiredUniqueChars = 1;
            })
            .AddEntityFrameworkStores<AppDbContext>()  
            .AddDefaultTokenProviders();  
        #endregion 
             
        
        #region localization

        builder.Services.AddLocalization();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSingleton<IStringLocalizerFactory, JSonStringLocalizerFactory>();
        builder.Services.AddMvc()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(  options =>
                {
                    options.DataAnnotationLocalizerProvider = (type , factory) =>
                        factory.Create(typeof(JSonStringLocalizerFactory));
                }
            );
        builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("ar-EG"),
                    new CultureInfo("en-US")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0] , uiCulture: supportedCultures[0] ); // arabic
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            }
        );
        #endregion
        
        var app = builder.Build();
        
        #region Role Seeding

        // Resolve RoleSeeder from DI and seed roles
        using (var scope = app.Services.CreateScope())
        {
            var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
            await  SeedRoles(roleSeeder);
        }

        #endregion
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
       
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseStaticFiles();
        #region localization
        var supportedCultures = new[] { "ar-EG", "en-US" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);
        app.UseRequestLocalization(localizationOptions);
        #endregion
        
        app.UseAuthentication();  
        app.UseAuthorization();
     // app.useRequestCulture(); //  if you donnot need to start app with arabic
                                  // and need to start with browser lang of user
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Home}/{id?}");

        app.Run();
        
    }
    private static async Task SeedRoles(RoleSeeder roleSeeder)
    {
        await roleSeeder.SeedRolesAsync();
    }
}