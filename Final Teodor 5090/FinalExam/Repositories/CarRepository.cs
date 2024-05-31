using FinalExam.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinalExam.Repositories
{
    public class CarRepository : ICarRepository
    {

        private readonly CarDbContext _carDbContext;

        public CarRepository(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }
        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carDbContext.Cars.ToListAsync();
        }

        public async Task<Car> GetById(int id)
        {
            return await _carDbContext.Cars.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Car> Create(Car car)
        {
            var result = await _carDbContext.Cars.AddAsync(car);
            await _carDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Car> Update(Car car)
        {
            var result = await _carDbContext.Cars.FirstOrDefaultAsync(e => e.Id == car.Id);

            if (result != null)
            {
                result.LicensePlate = car.LicensePlate;
                result.Manufacturer = car.Manufacturer;
                result.year= car.year;
                result.Model = car.Model;

                await _carDbContext.SaveChangesAsync();
                return result;

            }
            return null;

        }

        public async Task Delete(int id)
        {
            var result = await _carDbContext.Cars.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _carDbContext.Cars.Remove(result);
                await _carDbContext.SaveChangesAsync();
            }
        }

    }
}
