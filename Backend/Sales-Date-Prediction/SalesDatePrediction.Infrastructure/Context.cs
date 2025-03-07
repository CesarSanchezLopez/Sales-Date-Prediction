using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction.Core.Entities;

namespace SalesDatePrediction.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Shipper> Shipper { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Customer> Customer { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //    .Entity<Customer>(builder =>
        //    {
        //        builder.HasNoKey();
        //      //  builder.ToTable("MY_ENTITY");
        //    });
        //}
    }
}
