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
    public class CustomerRepository: ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context) // Constructor DI Injection
        {
            _context = context;
        }
        public async Task<List<Customer>> CustomerOrderPrediction()
        {
            List<Customer> list;
            string sql = "EXEC CustomerOrderPrediction";
            list = _context.Customer.FromSqlRaw<Customer>(sql).ToList();

            return await Task.FromResult(list);
        }
    }
}
