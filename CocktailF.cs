namespace ConsoleApp1;
public class CocktailF : DishF
{
    public override Food CreateDish()
    {
        return new Food("Cocktail", 10000);
    }
}