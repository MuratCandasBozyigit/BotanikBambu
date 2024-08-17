using Microsoft.EntityFrameworkCore;
using BotanikBambu.Data;
using BotanikBambu.Repository.Shared.Abstract;
using BotanikBambu.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using BotanikBambu.Business.Shared.Abstract;
using BotanikBambu.Business.Configuration; // BusinessDI ve RepositoryDI için gerekli

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Register repository implementations
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.LogoutPath = "/User/Login";
        options.Cookie.Name = "VkodCookie";
        options.SlidingExpiration = true;
    });

// Register services with DI
builder.Services.BusinessDI();
builder.Services.RepositoryDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
