using REST_API_CWICZNIA_4.DB;
using REST_API_CWICZNIA_4.Repository;
using REST_API_CWICZNIA_4.Type.Entity;

namespace REST_API_CWICZNIA_4.Type.Repository;

public class TypeRepository : SimpleRepository<TypeEntity, ICollection<TypeEntity>>
{
    private IMocDb _db;
    public TypeRepository(IMocDb db) : base(db.Types)
    {
        this._db = db;
    }

}