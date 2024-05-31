using FinalExam.Data.Models;
using FinalExam.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository carRepository;

        public CarController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCars()
        {
            try
            {
                return Ok(await carRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            try
            {
                var result = await carRepository.GetById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            try
            {
                if (car == null)
                    return BadRequest();

                var createdCar = await carRepository.Create(car);

                return CreatedAtAction(nameof(GetCar),
                    new { id = createdCar.Id }, createdCar);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new car record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Car>> UpdateCar(int id, Car car)
        {
            try
            {
                if (id != car.Id)
                    return BadRequest("Car ID mismatch");

                var carToUpdate = await carRepository.GetById(id);

                if (carToUpdate == null)
                    return NotFound($"Car with Id = {id} not found");

                return await carRepository.Update(car);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            try
            {
                var carToDelete = await carRepository.GetById(id);

                if (carToDelete == null)
                {
                    return NotFound($"Car with Id = {id} not found");
                }
                await carRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
