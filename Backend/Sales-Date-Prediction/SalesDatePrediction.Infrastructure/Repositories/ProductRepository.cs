using Microsoft.AspNetCore.Mvc;
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
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context) // Constructor DI Injection
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        { 
             List<Product> list;
             string sql = "EXEC Product_GetAll";
             list = _context.Product.FromSqlRaw<Product>(sql).ToList();

            return  await Task.FromResult(list);
        }

       

    }
}

