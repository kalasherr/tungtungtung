using DataAccessPostgres;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// 1. Добавляем DB
builder.Services.AddDbContext<ProgramDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(ProgramDbContext)));
});

// 2. Добавляем MVC
builder.Services.AddControllersWithViews();

// ✅ 3. Добавляем аутентификацию и авторизацию ДО builder.Build()
builder.Services.AddAuthentication("Auth")
    .AddCookie("Auth", options =>
    {
        options.LoginPath = "/Profile/Login"; // твой путь к логину
        options.AccessDeniedPath = "/Profile/AccessDenied";
    });

builder.Services.AddAuthorization();

// 4. Создаём приложение
var app = builder.Build();

// 5. Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Статические файлы
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "application/octet-stream"
});

var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".pck"] = "application/octet-stream";
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseStaticFiles();

// Роутинг + авторизация
app.UseRouting();

app.UseAuthentication(); // ⚠️ Обязательно до UseAuthorization
app.UseAuthorization();

// Роуты
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Запуск
app.Run();