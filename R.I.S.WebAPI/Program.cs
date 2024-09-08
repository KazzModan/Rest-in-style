using R.I.S.BLL;
using R.I.S.DAL;
using Microsoft.EntityFrameworkCore;
using R.I.S.DAL.Repositories;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the containe
builder.Services.AddDbContext<RISContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Server=localhost\\SQLEXPRESS;Database=RIS;Trusted_Connection=True;TrustServerCertificate=True;")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
