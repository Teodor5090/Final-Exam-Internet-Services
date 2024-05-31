using FinalExam.Data.Models;
using FinalExam.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetClients()
        {
            try
            {
                return Ok(await clientRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            try
            {
                var result = await clientRepository.GetById(id);

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
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            try
            {
                if (client == null)
                    return BadRequest();

                var createdClient = await clientRepository.Create(client);

                return CreatedAtAction(nameof(GetClient),
                    new { id = createdClient.Id }, createdClient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new client record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Client>> UpdateClient(int id, Client client)
        {
            try
            {
                if (id != client.Id)
                    return BadRequest("Client ID mismatch");

                var clientToUpdate = await clientRepository.GetById(id);

                if (clientToUpdate == null)
                    return NotFound($"Client with Id = {id} not found");

                return await clientRepository.Update(client);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            try
            {
                var clientToDelete = await clientRepository.GetById(id);

                if (clientToDelete == null)
                {
                    return NotFound($"Client with Id = {id} not found");
                }
                await clientRepository.Delete(id);
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
