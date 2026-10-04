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
        public MappingProfiles()
        {

            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.VehicleCount, opt => opt.MapFrom(src => src.Vehicles != null ? src.Vehicles.Count : 0));

            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();

            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.Category));

            CreateMap<CreateVehicleDTO, Vehicle>();
            CreateMap<UPdateVehicleDTO, Vehicle>();

            CreateMap<Customer, CustmorDTO>()
                .ForMember(dest => dest.TotalMoneySpent, opt => opt.MapFrom(src => src.Sales != null ? src.Sales.Sum(s => s.SalePrice) : 0))
                .ForMember(dest => dest.TotlaVehicles, opt => opt.MapFrom(src => src.Sales != null ? src.Sales.Count : 0));

            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustmorDTO, Customer>();

            CreateMap<CustomerProfile, CustmorProfileDTO>().ReverseMap();
            CreateMap<CreateCustmorProfileDTO, CustomerProfile>();
            CreateMap<UpdateCustmorProfileDTO, CustomerProfile>();

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(
                    dest => dest.SalesCount,
                    opt => opt.MapFrom(src => src.Sales != null ? src.Sales.Count : 0)
                )
                .ForMember(
                    dest => dest.TotalRevenue,
                    opt => opt.MapFrom(src => src.Sales != null
                        ? src.Sales.Sum(s => s.SalePrice)
                        : 0
                    )
                );


            CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, Employee>().ReverseMap();



            CreateMap<Sale, SaleDTO>()
                .ForMember(
                    dest => dest.Revenue,
                    opt => opt.MapFrom(src => src.SalePrice)
                );
        }
    }
}
