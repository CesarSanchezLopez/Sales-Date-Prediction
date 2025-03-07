using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;
using SalesDatePrediction.Infrastructure.Repositories;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepositor)
        {
            _employeeRepository = employeeRepositor;
        }


        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }
    }
}
