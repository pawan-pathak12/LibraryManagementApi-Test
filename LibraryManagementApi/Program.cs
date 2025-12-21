using LibraryManagementApi.Data;
using LibraryManagementApi.Interfaces.IRepositories;
using LibraryManagementApi.Interfaces.IServices;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<LibraryDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IAuthorEFRepository, AuthorEfRepository>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            //     app.UseSwaggerUI();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.Run();
    }
}