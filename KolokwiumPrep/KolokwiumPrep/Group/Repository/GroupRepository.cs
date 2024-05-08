using System.Data.SqlClient;
using KolokwiumPrep.Student.Entity;

namespace KolokwiumPrep.Group.Repository;

public class GroupRepository : IGroupRepository
{
    
    private readonly IConfiguration _configuration;
    
    public GroupRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<GroupEntity.GroupEntity> GetGroupById(int id)
    {
        await using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "Select ID, Name from Groups where ID = @id";
        cmd.Parameters.AddWithValue("id", id);

        using var dr = await cmd.ExecuteReaderAsync();
        
        GroupEntity.GroupEntity group = null;
        if (await dr.ReadAsync())
        {
            group = new GroupEntity.GroupEntity()
            {
                Id = (int)dr["ID"],
                Name = dr["Name"].ToString(),
                Students = new List<StudentEntity>()
            };
        }else
        {
            return null;
        }
        
        cmd.CommandText = "Select s.ID, s.FirstName, s.LastName, " +
                          "s.BirthDate, s.Phone " +
                          "from students s join StudentsGroups sg on s.ID = sg.StudentID " +
                          "where sg.GroupID = @id";
        await dr.CloseAsync();
        var dr2 = await cmd.ExecuteReaderAsync();

        while (await dr2.ReadAsync())
        {
            group.Students.Add(new StudentEntity()
            {
                Id = (int)dr2["ID"],
                FirstName = dr2["FirstName"].ToString(),
                LastName = dr2["LastName"].ToString(),
                BirthDate = (DateTime)dr2["BirthDate"],
                PhoneNumber = dr2["Phone"].ToString()
            });
        }

        return group;
    }
}