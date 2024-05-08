using KolokwiumPrep.Student.Entity;

namespace KolokwiumPrep.Student.Service;

public interface IStudentService
{
    Task<StudentEntity> getStudentById(int id);
    
    Task<bool> DeleteStudent(int id);
}