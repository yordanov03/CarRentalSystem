using CarRentalSystem.Domain.Models.Dealers;
using System;
using System.Linq.Expressions;

namespace CarRentalSystem.Domain.Specifications.Dealers
{
    public class DealerByNameSpecification : Specification<Dealer>
    {
        private readonly string? name;

        public DealerByNameSpecification(string? name)
        => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Dealer, bool>> ToExpression()
        => dealer => dealer.Name == this.name;
    }
}
