using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.Dealers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(string email)
        {
            this.Email = email;
        }

        public Dealer? Dealer { get; private set; }

        public void BecomeDealer(Dealer dealer)
        {
            if(this.Dealer != null)
            {
                throw new InvalidDealerException($"User {this.UserName} is already a dealer");
            }

            this.Dealer = dealer;
        }
    }
}
