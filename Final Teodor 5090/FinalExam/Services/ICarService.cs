using AutoMapper;
using FinalExam.Data.Models;
using FinalExam.Services.DTOs;

namespace FinalExam.Services
{
    public interface ICarService
    {

        Task<IEnumerable<CarDTO>> GetAll();
        Task<CarDTO> GetById(int id);
        Task<CarDTO> Create(CarDTO carDTO);
        Task Update(CarDTO carDTO);
        Task Delete(int id);
    }
}
