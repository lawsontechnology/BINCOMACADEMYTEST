using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BINCOMACADEMYTEST;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car> GetCarByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<List<Car>> GetCarsByExpressionAsync(Expression<Func<Car, bool>> predicate)
    {
        return await _context.Cars.Where(predicate).ToListAsync();
    }

    public async Task AddCarAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }
}
