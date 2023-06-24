namespace FruitStand;

public static class Extensions
{
    public static FruitDto AsDto(this Fruit fruit)
    {
        return new FruitDto
        {
            Id = fruit.Id,
            Name = fruit.Name,
            Price = fruit.Price,
            Quantity = fruit.Quantity
        };
    }
}