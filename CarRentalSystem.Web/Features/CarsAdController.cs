using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarsAdController : ControllerBase
    {
        private readonly IRepository<CarAd> carAds;
        public CarsAdController(IRepository<CarAd> carAds) => this.carAds = carAds;

        [HttpGet]
        public IEnumerable<CarAd> Get() => this.carAds.All().Where(c => c.IsAvailable);
    }
}
