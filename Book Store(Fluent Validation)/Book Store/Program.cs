using Book_Store.DBContext;
using Book_Store.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddDbContext<BookStoreDBContext>(options => options.UseInMemoryDatabase(databaseName:"InMemoryDataBase"));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        using (var scope = app.Services.CreateScope()) { 
        var serviceProvider = scope.ServiceProvider;
        DataGenerator.Initialize(serviceProvider);
         }


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
    }
}