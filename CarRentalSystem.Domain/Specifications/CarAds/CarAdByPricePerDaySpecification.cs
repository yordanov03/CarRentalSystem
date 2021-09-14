using CarRentalSystem.Domain.Models.CarAds;
using System;
using System.Linq.Expressions;

namespace CarRentalSystem.Domain.Specifications.CarAds
{
    public class CarAdByPricePerDaySpecification : Specification<CarAd>
    {
        private readonly decimal? minPricePerDay;
        private readonly decimal? maxPricePerDay;

        public CarAdByPricePerDaySpecification(decimal? minPricePerDay, decimal? maxPricePerDay)
        {
            this.minPricePerDay = minPricePerDay;
            this.maxPricePerDay = maxPricePerDay;
        }

        public override Expression<Func<CarAd, bool>> ToExpression()
        => carAd => this.minPricePerDay < carAd.PricePerDay && carAd.PricePerDay < this.maxPricePerDay;
    }
}
