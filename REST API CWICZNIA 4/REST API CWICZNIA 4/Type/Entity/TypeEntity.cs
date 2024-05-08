using REST_API_CWICZNIA_4.Repository;

namespace REST_API_CWICZNIA_4.Type.Entity;

public class TypeEntity : IEntity
{
    public long Id { get; set; }
    public string TName { get; set; }
}