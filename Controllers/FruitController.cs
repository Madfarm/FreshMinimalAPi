namespace FruitStand.Controllers;

[ApiController]
[Route("[controller]")]
public class FruitsController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public FruitsController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Fruit>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFruit([FromBody] FruitCreateDto fruitDto)
    {
        Fruit fruit = new()
        {
            Name = fruitDto.Name,
            Price = fruitDto.Price,
            Quantity = fruitDto.Quantity,
            DateCreated = DateTimeOffset.UtcNow
        };
        await _mongoDBService.CreateAsync(fruit);
        return CreatedAtAction(nameof(Get), new { id = fruit.Id }, fruit.AsDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFruit(string id, [FromBody] FruitUpdateDto changes)
    {
        
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteFruit(string id)
    // {

    // }
}