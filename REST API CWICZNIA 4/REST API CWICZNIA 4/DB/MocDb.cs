
using REST_API_CWICZNIA_4.Type.Entity;
using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.Record.Entity;

namespace REST_API_CWICZNIA_4.DB;

public class MocDb : IMocDb
{
    private ICollection<TypeEntity> _types;
    private ICollection<AnimalEntity> _animals;
    private ICollection<RecordEntity> _records;

    public MocDb()
    {
        _types = new List<TypeEntity>
        {
            new TypeEntity
            {
                Id = 1,
                TName = "Mouse"
            },
            new TypeEntity
            {
                Id = 2,
                TName = "Dog"
            },
            new TypeEntity
            {
                Id = 3,
                TName = "Cat"
            }
        };
        _animals = new List<AnimalEntity>()
        {
            new AnimalEntity()
            {
                Id = 1,
                Name = "Miki",
                TypeEntity = _types.ElementAt(0),
                Weight = 0.5,
                Color = "White"
            },
            new AnimalEntity()
            {
                Id = 2,
                Name = "Reksio",
                TypeEntity = _types.ElementAt(1),
                Weight = 10,
                Color = "Black"
            },
            new AnimalEntity()
            {
                Id = 3,
                Name = "Filemon",
                TypeEntity = _types.ElementAt(2),
                Weight = 5,
                Color = "Grey"
            }
        };
        _records = new List<RecordEntity>()
        {
            new RecordEntity()
            {
                Id = 1,
                Date = DateTime.Now,
                Description = "Miki is a good mouse",
                Animal = _animals.ElementAt(0),
                Price = 23.50
            },
            new RecordEntity()
            {
                Id = 2,
                Date = DateTime.Now,
                Description = "Reksio is a good dog",
                Animal = _animals.ElementAt(1),
                Price = 99.99
            }
        };
    }

    public ICollection<TypeEntity> Types => _types;
    public ICollection<AnimalEntity> Animals => _animals;
    public ICollection<RecordEntity> Records => _records;
}