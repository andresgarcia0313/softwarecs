using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using software.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();// Add services to the container.
// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=software.db";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
var app = builder.Build();
if (!app.Environment.IsDevelopment())// Configure the HTTP request pipeline.
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
