using Business.Abstract;
using Business.Concrete;
using DataAcces.Abstract;
using DataAcces.Concrate.EntityFramework;
using DataAcces.Concrate.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProjeContext>();

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

// Add services to the container.
builder.Services.AddControllersWithViews();


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
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();