using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CodingAssignment.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjectManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectManagementDbContext") ?? throw new InvalidOperationException("Connection string 'ProjectManagementDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=Index}/{id?}");

app.Run();
