using BuilderServicesOrganize.Infrastructure;
using BuilderServicesOrganize.Interface;
using BuilderServicesOrganize.Mapper;
using BuilderServicesOrganize.Repository;
using BuilderServicesOrganize.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ApplicationDbContext with the configured connection string
builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQL");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.Decorate<IEmployeeRepository, CachingEmployeeRepository>();

builder.Services.AddStackExchangeRedisCache((rediusOptions) =>
{
    var connectionString = builder.Configuration.GetConnectionString("Redis");
    rediusOptions.Configuration = connectionString;
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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
