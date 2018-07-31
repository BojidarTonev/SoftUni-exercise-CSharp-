using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.App.Dtos.Import;
using CarDealer.App.Dtos.Xport;
using CarDealer.Models;

namespace CarDealer.App
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Part, PartDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CarsFromMakeFerrariDto, CarDto>().ReverseMap();
        }
    }
}
