using BINCOMACADEMYTEST;
using Microsoft.AspNetCore.Mvc;

[Route("api/cars")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await _carService.GetAllCarsAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var car = await _carService.GetCarByIdAsync(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetCarsByFilter(decimal minPrice, decimal maxPrice)
    {
        var cars = await _carService.GetCarsByFilterAsync(c => c.Price >= minPrice && c.Price <= maxPrice);
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] CarCreateDto carDto)
    {
        await _carService.AddCarAsync(carDto);
        return Ok();
    }
}
