using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Infrastructure.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly Context _context;
        public ShipperRepository(Context context) // Constructor DI Injection
        {
            _context = context;
        }
        public async Task<List<Shipper>> GetAll()
        {
            List<Shipper> list;
            string sql = "EXEC Shipper_GetAll";
            list = _context.Shipper.FromSqlRaw<Shipper>(sql).ToList();

            return await Task.FromResult(list);
        }
    }
}
