using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _OrderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }


        [HttpGet]
        [Route("GetCustId/{id}")]
        public async Task<List<Order>> GetCustId(int id)
        {
            return await _OrderRepository.GetCustId(id);
        }

        [HttpPost] 
        public async Task<int> Post(Order order)
        {
            return await _OrderRepository.Post(order);
        }
        

    }
}
