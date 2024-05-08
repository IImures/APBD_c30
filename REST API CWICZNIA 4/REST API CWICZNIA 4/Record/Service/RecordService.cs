using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.Record.Controller.Request;
using REST_API_CWICZNIA_4.Record.Entity;
using REST_API_CWICZNIA_4.Repository;

namespace REST_API_CWICZNIA_4.Record.Service;

public class RecordService
{
    private SimpleRepository<RecordEntity, ICollection<RecordEntity>> _recordRepository;
    private SimpleRepository<AnimalEntity, ICollection<AnimalEntity>> _animalRepository;
    
    public RecordService(
        SimpleRepository<RecordEntity, ICollection<RecordEntity>> recordRepository,
        SimpleRepository<AnimalEntity, ICollection<AnimalEntity>> animalRepository
        )
    {
        _recordRepository = recordRepository;
        _animalRepository = animalRepository;
    }
    
    public List<RecordEntity> GetAll()   
    {
        return _recordRepository.GetAll();
    }

    public RecordEntity GetById(long id)
    {
        return _recordRepository.GetById(id);
    }

    public RecordEntity CreateRecord(RecordRequest recordRequest)
    {
        RecordEntity recordEntity = new RecordEntity
        {
            Price = recordRequest.Price ?? throw new InvalidOperationException(),
            Description = recordRequest.Description ?? throw new InvalidOperationException(),
            Date = recordRequest.Date ?? throw new InvalidOperationException(),
        };
        
        AnimalEntity animal = _animalRepository.GetById(recordRequest.AnimalId ?? throw new InvalidOperationException());
        recordEntity.Animal = animal;
        
        RecordEntity saved = _recordRepository.save(recordEntity);
        return saved;
    }

    public void DeleteRecord(long id)
    {
        _recordRepository.deleteById(id);
    }

    public RecordEntity UpdateRecord(int id, RecordRequest recordRequest)
    {
        RecordEntity record = _recordRepository.GetById(id);
        if (recordRequest.Description != null)
        {
            record.Description = recordRequest.Description;
        }
        if (recordRequest.Price != null)
        {
            record.Price = recordRequest.Price.Value;
        }
        if (recordRequest.Date != null)
        {
            record.Date = recordRequest.Date.Value;
        }
        if (recordRequest.AnimalId != null)
        {
            record.Animal = _animalRepository.GetById(recordRequest.AnimalId ?? throw new InvalidOperationException());
        }
        return record;
    }
    
}