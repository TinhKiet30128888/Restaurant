namespace ConsoleApp1;
public class SaladF : DishF
{
    public override Food CreateDish()
    {
        return new Food("Salad", 50000);
    }
}