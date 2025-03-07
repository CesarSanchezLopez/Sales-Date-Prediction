using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;

namespace SalesDatePrediction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperRepository _shipperRepository;
        public ShipperController(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }


        [HttpGet]
        public async Task<List<Shipper>> GetAll()
        {
            return await _shipperRepository.GetAll();
        }
    }
}
