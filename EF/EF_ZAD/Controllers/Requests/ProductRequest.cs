namespace EF_ZAD.Controllers.Requests;

public class ProductRequest
{
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }
    public List<int> Categories { get; set; }
    
}