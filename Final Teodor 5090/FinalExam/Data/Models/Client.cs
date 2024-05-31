using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(400)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(500)]
        public string Address { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        
    

    }
}
