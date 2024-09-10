using R.I.S.BLL;
using R.I.S.DAL;
using Microsoft.EntityFrameworkCore;
using R.I.S.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using R.I.S.BLL.Services;
using R.I.S.DAL.Abstracts;
using R.I.S.BLL.Services.Abstraction;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the containe
builder.Services.AddDbContext<RISContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddAutoMapper(typeof(ConfigurationMapper));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
builder.Services.AddMvc();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();
