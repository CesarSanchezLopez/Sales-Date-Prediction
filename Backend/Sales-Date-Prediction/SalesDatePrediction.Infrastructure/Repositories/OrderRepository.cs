using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        public OrderRepository(Context context) // Constructor DI Injection
        {
            _context = context;
        }
        public async Task<List<Order>> GetCustId(int id)
        {
            List<Order> list;
            string sql = "EXEC Order_GetCust @CustId";
            List<SqlParameter> parms = new List<SqlParameter>
            {
      
                new SqlParameter { ParameterName = "@CustId", Value = id }
            };

            list = _context.Order.FromSqlRaw<Order>(sql, parms.ToArray()).ToList();

            return await Task.FromResult(list);
        }
    }
}
