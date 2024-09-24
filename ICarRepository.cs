using System.Linq.Expressions;

namespace BINCOMACADEMYTEST;

public interface ICarRepository
{
    Task<List<Car>> GetCarsAsync();
    Task<Car> GetCarByIdAsync(int id);
    Task<List<Car>> GetCarsByExpressionAsync(Expression<Func<Car, bool>> predicate);
    Task AddCarAsync(Car car);
}
