namespace CarRentalSystem.Application.Features.CarAds.Commands
{
    public class CreateCarAdOutputModel
    {
        public CreateCarAdOutputModel(int carAdId)
                    => this.CarAdId = carAdId;

        public int CarAdId { get; }
    }
}
