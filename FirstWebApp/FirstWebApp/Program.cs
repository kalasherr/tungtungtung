﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.StaticFiles;
using FirstWebApp.Data;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DB>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles(new StaticFileOptions
        {
            ServeUnknownFileTypes = true,
            DefaultContentType    = "application/octet-stream"
        });

        var provider = new FileExtensionContentTypeProvider();
        provider.Mappings[".pck"] = "application/octet-stream";
        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider   = provider
        });

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    
        app.Run();
    }
}
