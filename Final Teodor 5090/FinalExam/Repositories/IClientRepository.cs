using FinalExam.Data.Models;

namespace FinalExam.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(int id);

        Task<Client> Create(Client client);

        Task<Client> Update(Client client);

        Task Delete(int id);

    }
}
