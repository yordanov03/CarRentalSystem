using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Models.Dealers;
using System;
using System.Collections.Generic;

namespace CarRentalSystem.Domain.Models.InitialData
{
    internal class DealerData : IInitialData
    {
        public Type EntityType => typeof(Dealer);

        public IEnumerable<object> GetData()
            => new List<Dealer>
        {
            new Dealer("This is a new dealer", "+3234234235325"),
            new Dealer("Yet another dealer", "+0989876433443")
        };
    }
}
