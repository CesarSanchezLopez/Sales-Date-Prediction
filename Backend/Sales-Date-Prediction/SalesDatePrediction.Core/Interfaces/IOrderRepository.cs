using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Core.Interfaces
{
    public interface IOrderRepository
    {
      //  Task<List<Order>> GetAll();
        Task<List<Order>> GetCustId(int id);

        Task<int> Post(Order product);


    }
}
