namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.SaleDTOs
{
    public class EmployeeSalesGroupDto
    {
        
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; } = string.Empty;
            public decimal TotalRevenue { get; set; }
            public int TotalSalesCount { get; set; }
            public List<SaleDTO> Sales { get; set; } = new List<SaleDTO>();
        
    }
}
