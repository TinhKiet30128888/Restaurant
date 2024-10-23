namespace ConsoleApp1;
public class NoodleF : DishF
{
    public override Food CreateDish()
    {
        return new Food("Noodle", 80000);
    }
}