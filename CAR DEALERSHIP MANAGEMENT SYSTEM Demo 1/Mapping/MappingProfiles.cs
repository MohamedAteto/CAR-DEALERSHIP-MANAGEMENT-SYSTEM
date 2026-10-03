using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CategoryDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.EmployeeDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.SaleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.VehicleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<Category, CategoryDTO>()
                .ForMember(s => s.VehicleCount, m => m
                .MapFrom(s => s.Vehicles.Count)).ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();


            CreateMap<Customer, CustmorDTO>().ReverseMap();
            CreateMap<Customer, CreateCustmorProfileDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustmorDTO>().ReverseMap();


            CreateMap<CustomerProfile, CustmorProfileDTO>().ReverseMap();
            CreateMap<CustomerProfile, CreateCustmorProfileDTO>().ReverseMap();
            CreateMap<CustomerProfile, UpdateCustmorProfileDTO>().ReverseMap();




            CreateMap<Employee, EmployeeDTO>()
                .ForMember(s => s.SalesCount , m => m.MapFrom(s => s.Sales.Count))
                .ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();


            CreateMap<Sale, SaleDTO>()
                .ForMember(s => s.VehicleVIN , m => m.MapFrom(s => s.Vehicle.VIN))
                .ReverseMap();
            CreateMap<Sale, CreateSaleDTO>().ReverseMap();
            CreateMap<Sale, UpdateSaleDTO>().ReverseMap();


            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Vehicle, CreateVehicleDTO>().ReverseMap();
            CreateMap<Vehicle, UPdateVehicleDTO>().ReverseMap();


        }
    }
}
