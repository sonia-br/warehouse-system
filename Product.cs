namespace Warehouse_system;

class Product
{

    public string Name;
    public int Quantity;
    public Status PStatus;

    public enum Status
    {
        InStock,
        OutOfStock,
        RefillNeeded,
        Ordered,
        AwaitingShipment
    }

    List<Product> allProducts = new List<Product>();

    public Product(string name, Status pStatus, int amount)
    {
        Name = name;
        PStatus = pStatus;
        Quantity = amount;

    }

    public static Status ChangeStatus(int quantity)
    {
        int n = quantity;
        if (n < 10 && n > 0)
        {
            return Status.RefillNeeded;
        }

        if (n == 0)
        {
            return Status.AwaitingShipment;
        }
        if (n>=10)
        {
            return Status.InStock;
        }
        else
        {
            Console.WriteLine("Amount of the product can't be negative");
            return Status.OutOfStock;
        }
    }

    
}