using SalesDatePrediction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();

    }
}
