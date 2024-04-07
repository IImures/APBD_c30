using REST_API_CWICZNIA_4.Animal.Controller.Request;
using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.Repository;
using REST_API_CWICZNIA_4.Type.Entity;

namespace REST_API_CWICZNIA_4.Animal.Service;

public class AnimalService
{

    private SimpleRepository<AnimalEntity, ICollection<AnimalEntity>> _animalRepository;
    private SimpleRepository<TypeEntity, ICollection<TypeEntity>> _typeRepository;
    
    public AnimalService(
        SimpleRepository<AnimalEntity, ICollection<AnimalEntity>> animalRepository,
        SimpleRepository<TypeEntity, ICollection<TypeEntity>> typeRepository)
    {
        _animalRepository = animalRepository;
        _typeRepository = typeRepository;
    }
    
    public List<AnimalEntity> GetAll()
    {
        return _animalRepository.GetAll();
    }

    public AnimalEntity GetById(long id)
    {
        return _animalRepository.GetById(id);
    }


    public AnimalEntity CreateAnimal(AnimalRequest animalRequest)
    {
        AnimalEntity animalEntity = new AnimalEntity
        {
            Name = animalRequest.Name ?? throw new InvalidOperationException(),
            Weight = animalRequest.Weight ?? throw new InvalidOperationException(),
            Color = animalRequest.Color ?? throw new InvalidOperationException(),
        };
        TypeEntity type = _typeRepository.GetById(animalRequest.TypeId ?? throw new InvalidOperationException());
        animalEntity.TypeEntity = type;
        
        AnimalEntity saved = _animalRepository.save(animalEntity);
        return saved;
    }

    public void DeleteAnimal(long id)
    {
        _animalRepository.deleteById(id);
    }

    public object? UpdateAnimal(long id, AnimalRequest animalRequest)
    {
        AnimalEntity animal = _animalRepository.GetById(id);
        if (animalRequest.Name != null) 
        {
            animal.Name = animalRequest.Name; 
        } 
        if (animalRequest.Color != null)
        {
            animal.Color = animalRequest.Color;
        }
        if (animalRequest.Weight != null)
        {
            animal.Weight = animalRequest.Weight.Value;
        }
        if (animalRequest.TypeId != null)
        {
            TypeEntity type = _typeRepository.GetById(animalRequest.TypeId.Value);
            animal.TypeEntity = type;
        }
        
        
        return animal;
    }
}