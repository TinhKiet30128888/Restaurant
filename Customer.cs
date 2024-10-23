namespace ConsoleApp1;
public class Customer : User
{
    public List<Order> Orders { get; private set; }

    public Customer(int id, string name, string email, string phone)
        : base(id, name, email, phone)
    {
        Orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Order:");
        foreach (var order in Orders)
        {
            order.DisplayOrder();
        }
    }
}