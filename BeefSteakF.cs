namespace ConsoleApp1;
public class BeefsteakF : DishF
{
    public override Food CreateDish()
    {
        return new Food("Beefsteak", 100000);
    }
}