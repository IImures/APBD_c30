namespace REST_API_CWICZNIA_4.Record.Controller.Request;

public class RecordRequest
{
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public long? AnimalId { get; set; }
    public double? Price { get; set; }
}