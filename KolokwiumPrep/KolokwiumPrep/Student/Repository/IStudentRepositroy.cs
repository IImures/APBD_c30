using KolokwiumPrep.Student.Entity;

namespace KolokwiumPrep.Student.Repository;

public interface IStudentRepository
{
    Task<StudentEntity?> getStudentById(int id);
    Task<bool> DeleteStudent(int id);
}