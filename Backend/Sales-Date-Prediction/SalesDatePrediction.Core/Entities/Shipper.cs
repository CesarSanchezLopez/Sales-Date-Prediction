using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Core.Entities
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }

        public string Phone { get; set; }
    }
}
