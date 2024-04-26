namespace Conncection_to_DB.ProductWarehouse.Entity;

public class ProductWarehouseEntity
{
    public long IdProductWarehouse { get; set; }
    public long IdWarehouse { get; set; }
    public long IdProduct { get; set; }
    public long IdOrder { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
}