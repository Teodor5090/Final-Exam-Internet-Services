using System.ComponentModel.DataAnnotations;

namespace FinalExam.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public int year { get; set; }


    }
}
