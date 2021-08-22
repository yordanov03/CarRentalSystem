using CarRentalSystem.Domain.Models.Dealers;
using System;

namespace CarRentalSystem.Domain.Factories.Dealers
{
    internal class DealerFactory : IDealerFactory
    {
        private string dealerName = default!;
        private string phoneNumber = default!;

        public Dealer Build()
        {
            return new Dealer(this.dealerName, this.phoneNumber);
        }

        public IDealerFactory WithName(string name)
        {
            this.dealerName = name;
            return this;
        }

        public IDealerFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }
    }
}
