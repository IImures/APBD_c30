
using KolokwiumPrep.Group.GroupEntity;
using KolokwiumPrep.Group.Repository;
using KolokwiumPrep.Group.Service;
using KolokwiumPrep.Student.Repository;
using KolokwiumPrep.Student.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();


        builder.Services.AddScoped<IGroupService, GroupService>();
        builder.Services.AddScoped<IGroupRepository, GroupRepository>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IStudentService, StudentService>();
        

        var app = builder.Build();

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
