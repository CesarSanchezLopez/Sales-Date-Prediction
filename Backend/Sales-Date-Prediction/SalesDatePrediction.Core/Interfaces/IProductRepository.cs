using SalesDatePrediction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace SalesDatePrediction.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        //Task<ActionResult<Product>> GetId(int id);

        //Task<int> Put(int id, Product product);

        //Task<int> Post(Product product);
        //Task<int> Delete(int id);
    }
}
