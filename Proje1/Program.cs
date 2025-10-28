using Business.Abstract;
using Business.Concrete;
using DataAcces.Abstract;
using DataAcces.Concrate.EntityFramework;
using DataAcces.Concrate.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IWriterDal, EfWriterDal>();
builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<IHeadingDal, EfHeadingDal>();
builder.Services.AddScoped<IHeadinService, HeadinManager>();
builder.Services.AddScoped<IContentDal, EfContentDal>();
builder.Services.AddScoped<IContentService, ContentManager>();
builder.Services.AddScoped<IAbautDal, EfAbautDal>();
builder.Services.AddScoped<IAbautService, AbautManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IImageDal, EfImageDal>();
builder.Services.AddScoped<IImageService, ImageManager>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

// Cookie Authentication
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Login/Index";          
        opt.AccessDeniedPath = "/ErrorPage/Index";
        opt.SlidingExpiration = true;
    });

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/ErrorPage/{0}");
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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
