using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.Interfaces;

namespace SalesDatePrediction.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context) // Constructor DI Injection
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAll()
        {
            List<Employee> list;
            string sql = "EXEC Employee_GetAll";
            list = _context.Employee.FromSqlRaw<Employee>(sql).ToList();

            return await Task.FromResult(list);
        }
    }
}
