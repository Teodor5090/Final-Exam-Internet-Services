using FinalExam.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CarDbContext _carDbContext;

        public ClientRepository(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _carDbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _carDbContext.Clients.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Client> Create(Client client)
        {
            var result = await _carDbContext.Clients.AddAsync(client);
            await _carDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Client> Update(Client client)
        {
            var result = await _carDbContext.Clients.FirstOrDefaultAsync(e => e.Id == client.Id);

            if (result != null)
            {
                result.FirstName = client.FirstName;
                result.LastName = client.LastName;
                result.DOB = client.DOB;
                result.Address = client.Address;
                result.Nationality = client.Nationality;
                result.StartDate = client.StartDate;
                result.EndDate = client.EndDate; 
              
                await _carDbContext.SaveChangesAsync();
                return result;

            }
            return null;

        }

        public async Task Delete(int id)
        {
            var result = await _carDbContext.Clients.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _carDbContext.Clients.Remove(result);
                await _carDbContext.SaveChangesAsync();
            }
        }
    }
}
