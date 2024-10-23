namespace ConsoleApp1;
public class Staff : User
{
    public string Position { get; private set; }

    public Staff(int id, string name, string email, string phone, string position)
        : base(id, name, email, phone)
    {
        Position = position;
    }
    public void CookOrder(Order order)
    {
        order.UpdateStatus("Cooking");
        Console.WriteLine($"Staff is cooking Order ID: {order.Id}");
    }

    public void ServeOrder(Order order)
    {
        order.UpdateStatus("Served");
        Console.WriteLine($"chef has served Order ID: {order.Id}");
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Position: {Position}");
    }
}