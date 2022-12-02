using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAssignment.API.Models
{
    public class DeliveryDates
    {
        public string postalCode { get; set; }

        public DateTime deliveryDate { get; set; }

        public bool isGreenDelivery { get; set; }
    }
}
