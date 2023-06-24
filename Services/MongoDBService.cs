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

    public async Task CreateAsync(Fruit fruit)
    {
        await _fruitsCollection.InsertOneAsync(fruit);

        return;
    }

    public async Task<List<Fruit>> GetAsync()
    {
        return await _fruitsCollection.Find(new BsonDocument()).ToListAsync();
    }
}