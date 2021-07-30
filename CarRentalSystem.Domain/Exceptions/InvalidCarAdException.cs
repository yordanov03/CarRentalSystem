using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Domain.Exceptions
{
   public class InvalidCarAdException : BaseDomainException
    {
        public InvalidCarAdException()
        {

        }

        public InvalidCarAdException(string message) => this.Message = message;
    }
}
