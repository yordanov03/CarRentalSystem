using CarRentalSystem.Domain.Models.CarAds;
using System;
using System.Linq.Expressions;

namespace CarRentalSystem.Domain.Specifications.CarAds
{
    public class CarAdByCategorySpecification : Specification<CarAd>
    {
        private readonly int? category;

        public CarAdByCategorySpecification(int? category)
        {
            this.category = category;
        }

        public override Expression<Func<CarAd, bool>> ToExpression()
        => carAd => carAd.Category.Id == this.category;
    }
}
