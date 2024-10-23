namespace ConsoleApp1;
public class Menu
{
    private static Menu _instance;
    public List<Food> Items { get; private set; }

    private Menu()
    {
        Items = new List<Food>();
    }
    // Singleton Pattern
    public static Menu Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Menu();
            }
            return _instance;
        }
    }

    public void AddItem(DishF factory)
    {
        Items.Add(factory.CreateDish());
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu");
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Items[i].Name} - {Items[i].Price} $");
        }
    }
}