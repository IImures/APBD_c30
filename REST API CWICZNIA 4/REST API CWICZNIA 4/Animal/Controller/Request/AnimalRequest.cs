namespace REST_API_CWICZNIA_4.Animal.Controller.Request;

public class AnimalRequest
{
    public string? Name { get; set; }
    public long? TypeId { get; set; }
    public double? Weight { get; set; }
    public string? Color { get; set; }
}