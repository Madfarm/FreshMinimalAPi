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
    public async Task<List<Fruit>> GetFruits()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpGet("{id}")]
    public async Task<FruitDto> GetFruit(string id)
    {
        var fruit = await _mongoDBService.GetFruitAsync(id);
        return fruit.AsDto();
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
        return CreatedAtAction(nameof(GetFruits), new { id = fruit.Id }, fruit.AsDto());
    }

    

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFruit(string id, [FromBody] FruitUpdateDto newFruit)
    {
        var existingFruit = await _mongoDBService.GetFruitAsync(id);

        if(existingFruit is null)
        {
            return NotFound();
        }

        Fruit updatedFruit = existingFruit with
        {
            Price = newFruit.Price,
            Quantity = newFruit.Quantity
        };

        await _mongoDBService.UpdateFruitAsync(updatedFruit);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFruit(string id)
    {
        var existingFruit = await _mongoDBService.GetFruitAsync(id);

        if (existingFruit is null)
        {
            return NotFound();
        }

        await _mongoDBService.DeleteFruitAsync(id);

        return NoContent();
    }
}