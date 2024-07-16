using Microsoft.EntityFrameworkCore;
using MohitAPICore.Contract;
using MohitAPICore.Models;
using MohitAPICore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<EmployeeDBOperation>();
builder.Services.AddTransient<IEmployee, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
