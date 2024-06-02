using KolokwiumPrep.Student.Entity;

namespace KolokwiumPrep.Group.GroupEntity;

public class GroupEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<StudentEntity> Students { get; set; }
}