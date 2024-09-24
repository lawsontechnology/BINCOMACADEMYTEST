using System.Linq.Expressions;

namespace BINCOMACADEMYTEST;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<List<CarDto>> GetAllCarsAsync()
    {
        var cars = await _carRepository.GetCarsAsync();
        return cars.Select(car => new CarDto
        {
            Id = car.Id,
            Name = car.Name,
            Price = car.Price,
            Description = car.Description,
            ImageUrl = car.ImageUrl
        }).ToList();
    }

    public async Task<CarDto> GetCarByIdAsync(int id)
    {
        var car = await _carRepository.GetCarByIdAsync(id);
        return car == null ? null : new CarDto
        {
            Id = car.Id,
            Name = car.Name,
            Price = car.Price,
            Description = car.Description,
            ImageUrl = car.ImageUrl
        };
    }

    public async Task<List<CarDto>> GetCarsByFilterAsync(Expression<Func<Car, bool>> filter)
    {
        var cars = await _carRepository.GetCarsByExpressionAsync(filter);
        return cars.Select(car => new CarDto
        {
            Id = car.Id,
            Name = car.Name,
            Price = car.Price,
            Description = car.Description,
            ImageUrl = car.ImageUrl
        }).ToList();
    }

    public async Task AddCarAsync(CarCreateDto carDto)
    {
        var car = new Car
        {
            Name = carDto.Name,
            Price = carDto.Price,
            Description = carDto.Description,
            ImageUrl = carDto.ImageUrl
        };
        await _carRepository.AddCarAsync(car);
    }
}
