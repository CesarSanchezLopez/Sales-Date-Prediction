using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public int? EmpId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipperId { get; set; }
        
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }//Null
        public string? ShippostalCode { get; set; }//Null
        public string? ShipCountry { get; set; }


        //Detalles de la orden
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Qty { get; set; }
        public decimal? Discount { get; set; }

    }
}
