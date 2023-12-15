using Book_Store.DBContext;
using Book_Store.DBOperations;
using Book_Store.Middlewares;
using Book_Store.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        //

        var builder = WebApplication.CreateBuilder(args);

        ConfigurationManager configuration = builder.Configuration;

        // Add services to the container.
        //Token nas�l �al��acag� belirtildi.
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {   
            // Token�n nas�l validate edilece�inin parametreleri verilir.
            opt.TokenValidationParameters = new TokenValidationParameters
            {   
                //kurallar verilir
                ValidateAudience = true, //Token� kimler kullanabilir
                ValidateIssuer = true, //Token�n da��t�c�s� kim 
                ValidateLifetime = true, //Token ya�am s�resini belirt
                ValidateIssuerSigningKey = true, //token� i�aretleyece�imiz key anahtar
                ValidIssuer = builder.Configuration["Token:Issuer"],
                ValidAudience = builder.Configuration["Token:Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                ClockSkew=TimeSpan.Zero

                 
            };


        });

        builder.Services.AddControllers();

        builder.Services.AddDbContext<BookStoreDBContext>(options => options.UseInMemoryDatabase(databaseName:"InMemoryDataBase"));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddSingleton<ILoggerService,ConsoleLogger>();

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

        app.UseAuthentication();
        
        app.UseHttpsRedirection();

        
        app.UseAuthorization();

        app.UseCustomExceptionMiddle();

        app.MapControllers();

        app.Run();
    }
}