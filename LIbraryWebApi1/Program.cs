using LIbraryWebApi1.AutoMapperProfiles;
using LIbraryWebApi1.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Create localDb
builder.Services.AddDbContext<LibraryDbContext>(opt =>
    opt.UseInMemoryDatabase("LocalLibraryDb"));
//Connect AutoMapper
builder.Services.AddAutoMapper(typeof(BookAutoMapperProfile), typeof(MagazineAutoMapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();