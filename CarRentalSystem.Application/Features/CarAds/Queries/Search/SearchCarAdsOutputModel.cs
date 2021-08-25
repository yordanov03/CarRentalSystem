using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    public class SearchCarAdsOutputModel
    {
        internal SearchCarAdsOutputModel(IEnumerable<CarAdListingModel> carAds, int total)
        {
            this.CarAds = carAds;
            this.Total = total;
        }

        public IEnumerable<CarAdListingModel> CarAds { get; }

        public int Total { get; }
    }
}
