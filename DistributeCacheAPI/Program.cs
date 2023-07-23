using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//first Step cashed repository
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<IMemberRepository, CachingMemberRepository>();
//first Step cashed repository

builder.Services.AddMemoryCache();
//builder.Services.Decorate<IMemberRepository, CachingMemberRepository>();


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
