namespace FruitStand.Dtos;

public record FruitCreateDto
{
    public string Name { get; init; } = null!;
    public int Price { get; init; }
    public int Quantity { get; init; }
}