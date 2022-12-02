using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAssignment.API.Models
{
    public class Product
    {
        public int productId { get; set; }

        public string name { get; set; }

        public List<DeliveryDate> DeliveryDates { get; set; }

        public ProductType productType { get; set; }

        public int daysInAdvance { get; set; }
    }
}
