namespace FruitStand.Dtos;

public record FruitUpdateDto
{
    public int Price { get; init; }
    public int Quantity { get; init; }
}