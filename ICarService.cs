using System.Linq.Expressions;

namespace BINCOMACADEMYTEST;

public interface ICarService
{
    Task<List<CarDto>> GetAllCarsAsync();
    Task<CarDto> GetCarByIdAsync(int id);
    Task<List<CarDto>> GetCarsByFilterAsync(Expression<Func<Car, bool>> filter);
    Task AddCarAsync(CarCreateDto carDto);
}
