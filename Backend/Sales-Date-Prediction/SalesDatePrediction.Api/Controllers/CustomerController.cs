using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;
using SalesDatePrediction.Infrastructure.Repositories;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("CustomerOrderPrediction")]
        public async Task<List<Customer>> CustomerOrderPrediction()
        {
            return await _customerRepository.CustomerOrderPrediction();
        }
    }
}
