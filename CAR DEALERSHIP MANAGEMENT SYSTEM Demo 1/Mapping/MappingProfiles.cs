using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CategoryDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.VehicleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(s => s.category, opt => opt.MapFrom(d => d.Category))
                .ReverseMap();

            CreateMap<Vehicle,CreateVehicleDTO>().ReverseMap();
            CreateMap<Vehicle, UPdateVehicleDTO>().ReverseMap();



            CreateMap<Category, CategoryDTO>()
                .ForMember(s => s.VehicleCount, opt => opt.MapFrom(d => d.Vehicles.Count))
                .ReverseMap();

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();





            CreateMap<Customer,CustmorDTO>()
                .ForMember(s => s.TotalMoneySpent, opt => opt.MapFrom(d => d.Sales.Sum(s => s.SalePrice)))
                .ForMember(s => s.TotlaVehicles, opt => opt.MapFrom(d => d.Sales.Count))
                .ReverseMap();

            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustmorDTO>().ReverseMap();

        }
    }
}
