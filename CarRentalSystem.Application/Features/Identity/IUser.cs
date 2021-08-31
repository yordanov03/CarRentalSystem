using CarRentalSystem.Domain.Models.Dealers;

namespace CarRentalSystem.Application.Features.Identity
{
    public interface IUser
    {
        void BecomeDealer(Dealer dealer);
    }
}
