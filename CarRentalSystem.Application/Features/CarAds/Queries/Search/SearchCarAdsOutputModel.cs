using CarRentalSystem.Application.Features.CarAds.Queries.Common;
using System.Collections.Generic;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    public class SearchCarAdsOutputModel : CarAdsOutputModel<CarAdOutputModel>
    {
        public SearchCarAdsOutputModel(IEnumerable<CarAdOutputModel> carAds,
            int page,
            int toalPages) : base(carAds, page, toalPages)
        {
        }
    }
}
