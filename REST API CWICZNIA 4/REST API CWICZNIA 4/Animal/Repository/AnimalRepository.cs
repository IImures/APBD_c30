using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.DB;
using REST_API_CWICZNIA_4.Repository;

namespace REST_API_CWICZNIA_4.Animal.Repository;

public class AnimalRepository : SimpleRepository<AnimalEntity, ICollection<AnimalEntity>>
{
    private IMocDb _db;
    public AnimalRepository(IMocDb db) : base(db.Animals)
    {
        this._db = db;
    }
}