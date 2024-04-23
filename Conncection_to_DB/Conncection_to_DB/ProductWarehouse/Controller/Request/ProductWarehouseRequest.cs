namespace Conncection_to_DB.ProductWarehouse.Controller.Request;

public class ProductWarehouseRequest
{
    public long IdProduct { get; set; }
    public long IdWarehouse { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}