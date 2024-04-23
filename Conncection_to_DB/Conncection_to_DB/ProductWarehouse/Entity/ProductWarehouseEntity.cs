namespace Conncection_to_DB.ProductWarehouse.Entity;

public class ProductWarehouseEntity
{
    long IdProductWarehouse { get; set; }
    long IdWarehouse { get; set; }
    long IdProduct { get; set; }
    long IdOrder { get; set; }
    int Amount { get; set; }
    double Price { get; set; }
    DateTime CreatedAt { get; set; }
}