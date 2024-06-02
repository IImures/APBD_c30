
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        //
        // builder.Services.AddScoped<IProductRepository, ProductRepository>();
        // builder.Services.AddScoped<IProductWarehouseRepository, ProductWarehouseRepository>();
        // builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>(); 
        // builder.Services.AddScoped<IProductWarehouseService, ProductWarehouseService>();
        // builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>(); 
        // builder.Services.AddScoped<IOrderRepository, OrderRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
        app.Run();
    }
}