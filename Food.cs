namespace ConsoleApp1;
public class Food
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Food(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}