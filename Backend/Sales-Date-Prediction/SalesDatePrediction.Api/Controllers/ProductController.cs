using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       
        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
    }
}
