using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAssignment.API.Models;

namespace TechAssignment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryController : ControllerBase
    {
        #region Seed
        List<Product> products = new List<Product>(){
            new Product {
                productId = 1,
                name = "Gurka",
                productType = ProductType.Normal,
                daysInAdvance = 1,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=6},
                    new DeliveryDate { WeekDay=1},
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=5}
                }
            },
            new Product {
                productId = 2,
                name = "Tomat",
                productType = ProductType.Normal,
                daysInAdvance = 2,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=6}
                }
            }
            ,
            new Product {
                productId = 3,
                name = "Paprika",
                productType = ProductType.Normal,
                daysInAdvance = 1,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=6},
                    new DeliveryDate { WeekDay=1},
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=5}
                }
            },
            new Product {
                productId = 4,
                name = "Isbergssallad",
                productType = ProductType.Normal,
                daysInAdvance = 1,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=6},
                    new DeliveryDate { WeekDay=1},
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=5}
                }
            },
            new Product {
                productId = 5,
                name = "Ägg",
                productType = ProductType.Normal,
                daysInAdvance = 2,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=6}
                }
            },
            new Product {
                productId = 6,
                name = "Mellanmjölk",
                productType = ProductType.Normal,
                daysInAdvance = 1,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=6},
                    new DeliveryDate { WeekDay=1},
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=5}
                }
            },
            new Product {
                productId = 7,
                name = "Bregott",
                productType = ProductType.Normal,
                daysInAdvance = 1,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=6},
                    new DeliveryDate { WeekDay=1},
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=5}
                }
            },
            new Product {
                productId = 8,
                name = "Rökt Kalkon",
                productType = ProductType.Normal,
                daysInAdvance = 2,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=2},
                    new DeliveryDate { WeekDay=4},
                    new DeliveryDate { WeekDay=6}
                }
            },
            new Product {
                productId = 9,
                name = "Ketchup",
                productType = ProductType.Normal,
                daysInAdvance = 3,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=5}
                }
            },
            new Product {
                productId = 10,
                name = "Spagetti",
                productType = ProductType.Normal,
                daysInAdvance = 3,
                DeliveryDates = new List<DeliveryDate>()
                {
                    new DeliveryDate { WeekDay=3},
                    new DeliveryDate { WeekDay=5}
                }
            }
        };
        #endregion
        6
        [HttpGet]
        public IEnumerable<DeliveryDates> Get(string postCode = "12345")
        {
            var deliveryDates = new List<DeliveryDates>();
            var product = products.OrderByDescending(x => x.daysInAdvance).First();
            List<int> prodDeliveryDay = new List<int>();
            foreach (var d in product.DeliveryDates)
                prodDeliveryDay.Add(d.WeekDay);
            var firstAvailableDelivery = DateTime.Today.AddDays(product.daysInAdvance);
            int day = (int)firstAvailableDelivery.DayOfWeek;
            for (int i = 0 + product.daysInAdvance; i < 14; i++)
            {
                if (prodDeliveryDay.Contains(day))
                {
                    deliveryDates.Add(new DeliveryDates { postalCode = postCode, deliveryDate = firstAvailableDelivery.AddDays(i).AddHours(10).AddMinutes(30), isGreenDelivery = true });
                    deliveryDates.Add(new DeliveryDates { postalCode = postCode, deliveryDate = firstAvailableDelivery.AddDays(i).AddHours(19).AddMinutes(30), isGreenDelivery = false });
                    firstAvailableDelivery.AddDays(i);
                    if (day != 7)
                        day += 1;
                    else
                        day = 1;
                }
                else
                {
                    firstAvailableDelivery.AddDays(i);
                    if (day != 7)
                        day += 1;
                    else
                        day = 1;
                } 
            }
            return JsonResult(deliveryDates.OrderBy(x => x.deliveryDate));
                
        }
    }
}
