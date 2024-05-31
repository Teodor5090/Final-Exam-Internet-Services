using FinalExam.Services.DTOs;

namespace FinalExam.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAll();
        Task<ClientDTO> GetById(int id);
        Task<ClientDTO> Create(ClientDTO clientDTO);
        Task Update(ClientDTO clientDTO);
        Task Delete(int id);

    }
}
