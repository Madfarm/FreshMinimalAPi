namespace FruitStand.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Fruit> _fruitsCollection;
    private readonly FilterDefinitionBuilder<Fruit> filterBuilder = Builders<Fruit>.Filter;

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

    public async Task<Fruit> GetFruitAsync(string id)
    {
        var filter = filterBuilder.Eq(fruit => fruit.Id, id);
        return await _fruitsCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<ReplaceOneResult> UpdateFruitAsync(Fruit newFruit)
    {
        var filter = filterBuilder.Eq(item => item.Id, newFruit.Id);
        return await _fruitsCollection.ReplaceOneAsync(filter, newFruit);
    }

    public async Task<DeleteResult> DeleteFruitAsync(string id)
    {
        var filter = filterBuilder.Eq(fruit => fruit.Id, id);
        return await _fruitsCollection.DeleteOneAsync(filter);
    }
}