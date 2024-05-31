using AutoMapper;
using FinalExam.Data.Models;
using FinalExam.Repositories;
using FinalExam.Services.DTOs;

namespace FinalExam.Services
{
    public class CarService : ICarService
    {

        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDTO>> GetAll()
        {
            var car = await _carRepository.GetAll();
            return _mapper.Map<IEnumerable<CarDTO>>(car);
        }

        public async Task<CarDTO> GetById(int id)
        {
            var car = await _carRepository.GetById(id);
            return _mapper.Map<CarDTO>(car);
        }

        public async Task<CarDTO> Create(CarDTO carDTO)
        {
            var car = _mapper.Map<Car>(carDTO);
            car = await _carRepository.Create(car);
            return _mapper.Map<CarDTO>(car);
        }

        public async Task Update(CarDTO guestDTO)
        {
            var guest = _mapper.Map<Car>(guestDTO);
            await _carRepository.Update(guest);
        }

        public async Task Delete(int id)
        {
            await _carRepository.Delete(id);
        }
    }
}
