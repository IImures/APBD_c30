using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.Record.Entity;
using REST_API_CWICZNIA_4.Type.Entity;

namespace REST_API_CWICZNIA_4.DB;

public interface IMocDb
{
    public ICollection<TypeEntity> Types { get; }
    public ICollection<AnimalEntity> Animals { get; }
    public ICollection<RecordEntity> Records { get; }
}