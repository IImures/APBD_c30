
using REST_API_CWICZNIA_4;
using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.Animal.Repository;
using REST_API_CWICZNIA_4.Animal.Service;
using REST_API_CWICZNIA_4.DB;
using REST_API_CWICZNIA_4.Record.Entity;
using REST_API_CWICZNIA_4.Record.Repository;
using REST_API_CWICZNIA_4.Record.Service;
using REST_API_CWICZNIA_4.Repository;
using REST_API_CWICZNIA_4.Type.Entity;
using REST_API_CWICZNIA_4.Type.Repository;
using REST_API_CWICZNIA_4.Type.Service;

public class Program{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        builder.Services.AddSingleton<IMocDb, MocDb>();
        builder.Services.AddScoped<SimpleRepository<TypeEntity, ICollection<TypeEntity>>, TypeRepository>();
        builder.Services.AddScoped<TypeService>();

        builder.Services.AddScoped<SimpleRepository<AnimalEntity, ICollection<AnimalEntity>>, AnimalRepository>();
        builder.Services.AddScoped<AnimalService>();

        builder.Services.AddScoped<SimpleRepository<RecordEntity, ICollection<RecordEntity>>, RecordRepository>();
        builder.Services.AddScoped<RecordService>();
       

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
    }
}