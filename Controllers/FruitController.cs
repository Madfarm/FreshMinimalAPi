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

    }

    [HttpPost]
    public async Task<IActionResult> CreateFruit([FromBody] FruitCreateDto fruit)
    {

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFruit(string id, [FromBody] )
    {

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFruit(string id)
    {

    }
}