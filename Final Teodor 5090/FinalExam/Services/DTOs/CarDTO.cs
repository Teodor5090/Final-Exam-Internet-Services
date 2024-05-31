using System.ComponentModel.DataAnnotations;

namespace FinalExam.Services.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }

      
        public string LicensePlate { get; set; }

    
        public string Model { get; set; }

    
        public string Manufacturer { get; set; }

     
        public int year { get; set; }
    }
}
