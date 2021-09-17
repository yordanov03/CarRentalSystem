using CarRentalSystem.Application.Mapping;
using CarRentalSystem.Domain.Models.Dealers;

namespace CarRentalSystem.Application.Features.Dealers.Queries.Search
{
    public class SearchDealerOutputModel
    {

        internal SearchDealerOutputModel(int id, string name, string phoneNumber, int totalCarAds)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.TotalCarAds = totalCarAds;
        }

        public int Id { get; }

        public string Name { get; }

        public string PhoneNumber { get; }

        public int TotalCarAds { get; }


    }
}
