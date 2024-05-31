using FinalExam.Data.Models;

namespace FinalExam.Repositories
{
    public interface ICarRepository
    {
        public Task<IEnumerable<Car>> GetAll();
        public Task<Car> GetById(int id);

        public Task<Car> Create(Car car);

        public Task<Car> Update(Car car);

        public Task Delete(int id);




    }
}
