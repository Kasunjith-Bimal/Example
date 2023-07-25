using DistributeCacheAPI.Interface;
using DistributeCacheAPI.Repository;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//first Step cashed repository
//builder.Services.AddScoped<MemberRepository>();
//builder.Services.AddScoped<IMemberRepository, CachingMemberRepository>();
//first Step cashed repository

//second Step cashed repository
//builder.Services.AddScoped<MemberRepository>();
//builder.Services.AddScoped<IMemberRepository>(provider =>
//{
//    var memberRepository = provider.GetService<MemberRepository>();
//    return new CachingMemberRepository(memberRepository, provider.GetService<IMemoryCache>()!);
//});
//second Step cashed repository


//thered (scorter library)
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.Decorate<IMemberRepository, CachingMemberRepository>();

//thered 

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
