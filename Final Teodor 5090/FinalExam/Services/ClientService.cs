using AutoMapper;
using FinalExam.Data.Models;
using FinalExam.Repositories;
using FinalExam.Services.DTOs;

namespace FinalExam.Services
{
    public class ClientService : IClientService
    { 
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> GetAll()
    {
        var client = await _clientRepository.GetAll();
        return _mapper.Map<IEnumerable<ClientDTO>>(client);
    }

    public async Task<ClientDTO> GetById(int id)
    {
        var client = await _clientRepository.GetById(id);
        return _mapper.Map<ClientDTO>(client);
    }

    public async Task<ClientDTO> Create(ClientDTO clientDTO)
    {
        var client = _mapper.Map<Client>(clientDTO);
        client = await _clientRepository.Create(client);
        return _mapper.Map<ClientDTO>(client);
    }

    public async Task Update(ClientDTO guestDTO)
    {
        var guest = _mapper.Map<Client>(guestDTO);
        await _clientRepository.Update(guest);
    }

    public async Task Delete(int id)
    {
        await _clientRepository.Delete(id);
    }
}
}
