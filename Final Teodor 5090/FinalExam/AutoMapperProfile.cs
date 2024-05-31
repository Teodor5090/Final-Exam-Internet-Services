using AutoMapper;
using FinalExam.Data.Models;
using FinalExam.Services.DTOs;


namespace FinalExam
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
        }
    }

}
