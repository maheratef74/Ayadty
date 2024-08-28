using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace presentationLayer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        var app = builder.Build();
        
        var supportedCultures = new[] { "en-US", "ar-SA" };
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("ar-SA"),
            SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
            SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList()
        };
        app.UseRequestLocalization(localizationOptions);
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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=auth}/{action=Register}/{id?}");

        app.Run();
        
    }
}