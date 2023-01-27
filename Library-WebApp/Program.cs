using LibraryWebApi1.AutoMapperProfiles;
using LibraryWebApi1.Data;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Create localDb
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMagazineRepository, MagazineRepository>();
builder.Services.AddDbContext<LibraryDbContext>(opt =>
    opt.UseInMemoryDatabase("LocalLibraryDb"));
//add AutoMapper
builder.Services.AddAutoMapper(typeof(BookAutoMapperProfile), typeof(MagazineAutoMapperProfile));
//add Search Services

builder.Services.AddScoped<BookSearch>();
builder.Services.AddScoped<ISearchByName<BookDTO,IBookRepository>>(serv => serv.GetRequiredService<BookSearch>());
builder.Services.AddScoped<ISearchByGenre>(serv => serv.GetRequiredService<BookSearch>());
builder.Services.AddScoped<ISearchByName<LibraryDTO,ILibraryRepository>, LibrarySearch>();
builder.Services.AddScoped<ISearchByName<MagazineDTO,IMagazineRepository>, MagazineSearch>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseWelcomePage();
app.MapControllers();
app.Run();