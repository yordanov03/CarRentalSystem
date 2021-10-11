using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Models.CarAds;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.Domain.Models.InitialData
{
    internal class ManufacturerData : IInitialData
    {
        public Type EntityType => typeof(Manufacturer);

        public IEnumerable<object> GetData()
            => new List<Manufacturer>
        {
            new Manufacturer("BavariaAuto"),
            new Manufacturer("SomeDealership"),
            new Manufacturer("AnotherDealership")
        };
    }
}
