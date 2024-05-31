using System.ComponentModel.DataAnnotations;

namespace FinalExam.Services.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
