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
        public async Task<int> Post(Order order)
        {
            int result = 0;
            string sql = "EXEC Order_Insert @custId, @empid ,@orderdate ,@requireddate , @shippeddate ,@shipperid ," +
                " @freight, @shipname,@shipaddress ,@shipcity, @shipcountry, @productid ,@unitprice, @qty, @discount";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@custId", Value = order.CustId },
                new SqlParameter { ParameterName = "@empid", Value = order.EmpId },
                new SqlParameter { ParameterName = "@orderdate", Value = order.OrderId },
                new SqlParameter { ParameterName = "@requireddate", Value = order.RequiredDate },
                new SqlParameter { ParameterName = "@shippeddate", Value = order.ShippedDate },
                new SqlParameter { ParameterName = "@shipperid", Value = order.ShipperId },
                new SqlParameter { ParameterName = "@freight", Value = order.Freight },
                new SqlParameter { ParameterName = "@shipname", Value = order.ShipName },
                new SqlParameter { ParameterName = "@shipaddress", Value = order.ShipAddress },
                new SqlParameter { ParameterName = "@shipcity", Value = order.ShipCity },
                new SqlParameter { ParameterName = "@shipcountry", Value = order.ShipCountry },


                //Detalles de la orden
                new SqlParameter { ParameterName = "@productid", Value = order.ProductId },
                new SqlParameter { ParameterName = "@unitprice", Value = order.UnitPrice },
                new SqlParameter { ParameterName = "@qty", Value = order.Qty },
                new SqlParameter { ParameterName = "@discount", Value = order.Discount }
            };

            result = _context.Database.ExecuteSqlRaw(sql, parms.ToArray());

            return await Task.FromResult(result);
        }
    }
}
