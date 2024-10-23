namespace ConsoleApp1;
public class Order
{
    public int Id { get; private set; }
    public List<Food> Items { get; private set; }
    public string Status { get; private set; }

    public User Customer { get; private set; }

    public Order(int id)
    {
        Id = id;
        Items = new List<Food>();
        Status = "Pending";
    }

    public void AssignCustomer(User customer) {
        Customer = customer;
    }

    public void AddItem(Food item)
    {
        Items.Add(item);
    }
    public void UpdateStatus(string status)
    {
        Status = status;
    }
    public void DisplayOrder()
    {
        Console.WriteLine($"Order ID: {Id}");
        Console.WriteLine("Items:");
        foreach (var item in Items)
        {
            Console.WriteLine($"- {item.Name}");
        }
        Console.WriteLine($"Status: {Status}");
    }
}