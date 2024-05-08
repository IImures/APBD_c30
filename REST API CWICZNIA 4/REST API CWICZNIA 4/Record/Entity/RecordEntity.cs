using REST_API_CWICZNIA_4.Animal.Entity;
using REST_API_CWICZNIA_4.Repository;

namespace REST_API_CWICZNIA_4.Record.Entity;

public class RecordEntity : IEntity
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public AnimalEntity Animal { get; set; }
    public double Price { get; set; }
}