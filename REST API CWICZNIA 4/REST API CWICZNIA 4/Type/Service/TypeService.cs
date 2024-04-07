using REST_API_CWICZNIA_4.Repository;
using REST_API_CWICZNIA_4.Type.Controller.Request;
using REST_API_CWICZNIA_4.Type.Entity;


namespace REST_API_CWICZNIA_4.Type.Service;

public class TypeService
{
    private SimpleRepository<TypeEntity, ICollection<TypeEntity>> _typeRepository;

    public TypeService(SimpleRepository<TypeEntity, ICollection<TypeEntity>> typeRepository)
    {
        _typeRepository = typeRepository;
    }

    public List<TypeEntity> GetAll()   
    {
        return _typeRepository.GetAll();
    }

    public TypeEntity GetById(long id)
    {
        return _typeRepository.GetById(id);
    }

    public TypeEntity CreateType(TypeRequest typeRequest)
    {
        TypeEntity typeEntity = new TypeEntity
        {
            TName = typeRequest.TName
        };
        TypeEntity saved = _typeRepository.save(typeEntity);
        return saved;
    }

    public void DeleteType(long id)
    {
       _typeRepository.deleteById(id);
    }

    public TypeEntity UpdateType(int id, TypeRequest typeRequest)
    {
        TypeEntity type = _typeRepository.GetById(id);
        type.TName = typeRequest.TName;
        return type;
    }
}