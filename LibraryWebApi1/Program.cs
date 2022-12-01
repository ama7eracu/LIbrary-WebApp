using LibraryWebApi1.AutoMapperProfiles;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services;
using LibraryWebApi1.Services.Interfaces;
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
//add Search Services
builder.Services.AddScoped<BookSearch>();
builder.Services.AddScoped<ISearchByName<BookDto>>(serv => serv.GetRequiredService<BookSearch>());
builder.Services.AddScoped<ISearchByGenre>(serv => serv.GetRequiredService<BookSearch>());
builder.Services.AddScoped<ISearchByName<LibraryDTO>, LibrarySearch>();
builder.Services.AddScoped<ISearchByName<MagazineDto>, MagazineSearch>();
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