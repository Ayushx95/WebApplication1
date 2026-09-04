
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("StudentsDb"));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAttendanceRepository, WebApplication1.Repositories.AttendanceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Seed data using the repository (async)
using (var scope = app.Services.CreateScope())
{
    var repo = scope.ServiceProvider.GetRequiredService<IStudentRepository>();
    var list = await repo.GetAllStudentsAsync();
    if (list == null || list.Count == 0)
    {
        await repo.AddStudentAsync(new Student { Name = "Alice", Email = "alice@example.com", Age = 20 });
        await repo.AddStudentAsync(new Student { Name = "Bob", Email = "bob@example.com", Age = 22 });
    }
}


app.Run();
