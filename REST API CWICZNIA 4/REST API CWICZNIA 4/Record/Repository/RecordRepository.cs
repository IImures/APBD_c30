using REST_API_CWICZNIA_4.DB;
using REST_API_CWICZNIA_4.Record.Entity;
using REST_API_CWICZNIA_4.Repository;

namespace REST_API_CWICZNIA_4.Record.Repository;

public class RecordRepository : SimpleRepository<RecordEntity, ICollection<RecordEntity>>
{
    private IMocDb _db;
    public RecordRepository(IMocDb db) : base(db.Records)
    {
        _db = db;
    }
}