using CarRentalSystem.Domain.Models.CarAds;
using System;
using System.Linq.Expressions;

namespace CarRentalSystem.Domain.Specifications.CarAds
{
    public class CarAdOnlyAvailableSpecification : Specification<CarAd>
    {
        private bool onlyAvailable { get; }

        public CarAdOnlyAvailableSpecification(bool onlyAvailable)
        {
            this.onlyAvailable = onlyAvailable;
        }
        public override Expression<Func<CarAd, bool>> ToExpression()
        {
            if (this.onlyAvailable)
            {
                return carAd => carAd.IsAvailable;
            }

            return carAd => true;
        }
    }
}
