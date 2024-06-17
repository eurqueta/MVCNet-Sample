using Microsoft.EntityFrameworkCore;
using MVCNet.Models;
using MVCNet.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IProfileService,ProfileService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
