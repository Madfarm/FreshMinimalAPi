namespace FruitStand.Models;

public record Fruit
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    public string Name { get; init; } = null!;
    public int Price { get; init; }
    public int Quantity { get; init; }
    public DateTimeOffset DateCreated { get; init; }
}