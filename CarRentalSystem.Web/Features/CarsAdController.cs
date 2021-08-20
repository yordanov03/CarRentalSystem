using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarsAdController : ControllerBase
    {
        private static readonly Dealer Dealer = new Dealer("Dealer", "+123456789");

        [HttpGet]
        public IEnumerable<CarAd> Get() => Dealer.CarAds.Where(c => c.IsAvailable);
    }
}
