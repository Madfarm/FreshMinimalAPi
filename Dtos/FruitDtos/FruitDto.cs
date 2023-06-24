namespace FruitStand.Dtos;

public record FruitDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; init; }
    public string Name { get; init; } = null!;
    public int Price { get; init; }
    public int Quantity { get; init; }
}