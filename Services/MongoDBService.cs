namespace FruitStand.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Fruit> _fruitsCollection;

    public MongoDBService(IOptions<FruitStandDatabaseSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _fruitsCollection = database.GetCollection<Fruit>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(FruitCreateDto fruit)
    {
        Fruit newFruit = new()
        {
            Name = fruit.Name,
            Price = fruit.Price,
            Quantity = fruit.Quantity
        };
        await _fruitsCollection.InsertOneAsync(newFruit);

        return;
    }

    public async Task<List<Fruit>> GetAsync()
    {
        return await _fruitsCollection.Find(new BsonDocument()).ToListAsync();
    }
}