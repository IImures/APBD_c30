
using EF_ZAD.Context;
using EF_ZAD.Middlewares;
using EF_ZAD.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
       // builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<ApplicationContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information)
            );
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IProductService, ProductService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            // app.UseSwagger();
            // app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionHandler>();
        
        app.MapControllers();
        app.UseHttpsRedirection();
        app.Run();
    }
}