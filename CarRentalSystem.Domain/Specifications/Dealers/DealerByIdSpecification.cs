using CarRentalSystem.Domain.Models.Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Specifications.Dealers
{
    public class DealerByIdSpecification : Specification<Dealer>
    {
        private readonly int? id;

        public DealerByIdSpecification(int? id)
        => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Dealer, bool>> ToExpression()
        => dealer => dealer.Id == this.id;
    }
}
