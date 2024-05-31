using Microsoft.EntityFrameworkCore;
using FinalExam.Data.Models;


namespace FinalExam
{
    public class CarDbContext : DbContext
    {
        private readonly CarDbContext _context;
        
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) 
        {
        }
      

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }

      
    }
}
