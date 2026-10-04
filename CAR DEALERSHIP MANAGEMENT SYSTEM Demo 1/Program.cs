using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVehicleRepo,VehicleRepo>();
builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
builder.Services.AddScoped<ICustomerRepo,CustomerRepo>();
builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();
builder.Services.AddScoped<ISaleRepo, SaleRepo>();
builder.Services.AddScoped<ICustomerProfileRepo,CustomerProfileRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
