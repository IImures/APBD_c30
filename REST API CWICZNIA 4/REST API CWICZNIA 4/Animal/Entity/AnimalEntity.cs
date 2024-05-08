using REST_API_CWICZNIA_4.Repository;
using REST_API_CWICZNIA_4.Type.Entity;

namespace REST_API_CWICZNIA_4.Animal.Entity;

public class AnimalEntity : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public TypeEntity TypeEntity { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }
}