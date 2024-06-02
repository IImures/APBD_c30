using EF_ZAD.Entities;

namespace EF_ZAD.Controllers.Responses;

public class ProductResponse
{
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }
    public int ProductId { get; set; }

    public List<object> Categories { get; set; }}