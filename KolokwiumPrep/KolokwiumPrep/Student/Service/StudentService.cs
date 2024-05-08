using KolokwiumPrep.Student.Entity;
using KolokwiumPrep.Student.Repository;

namespace KolokwiumPrep.Student.Service;

public class StudentService : IStudentService
{
    
    private readonly IStudentRepository _studentRepository;
    
    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public async Task<StudentEntity> getStudentById(int id)
    {
        return await _studentRepository.getStudentById(id);
    }

    public async Task<bool> DeleteStudent(int id)
    {
        return await _studentRepository.DeleteStudent(id);
    }
}