using System.Data.SqlClient;
using KolokwiumPrep.Student.Entity;

namespace KolokwiumPrep.Student.Repository;

public class StudentRepository : IStudentRepository
{
    
    private readonly IConfiguration _configuration;
    
    public StudentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<StudentEntity?> getStudentById(int id)
    {
        await using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Select ID, FirstName, LastName, BirthDate, Phone from students where ID = @id";
        cmd.Parameters.AddWithValue("id", id);

        var dr = await cmd.ExecuteReaderAsync();
        
        StudentEntity student = null;
        if (await dr.ReadAsync())
        {
            student = new StudentEntity()
            {
                Id = (int)dr["ID"],
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                BirthDate = (DateTime)dr["BirthDate"],
                PhoneNumber = dr["Phone"].ToString()
            };
        }

        return student;
    }

    public async Task<bool> DeleteStudent(int id)
    {
        await using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await con.OpenAsync();
        
        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Delete from students where ID = @id";
        cmd.Parameters.AddWithValue("id", id);
        
        var dr = await cmd.ExecuteNonQueryAsync();
        
        return dr > 0;
    }
}