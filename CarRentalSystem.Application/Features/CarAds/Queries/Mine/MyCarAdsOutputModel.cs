using CarRentalSystem.Application.Features.CarAds.Queries.Common;
using System.Collections.Generic;

namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    public class MyCarAdsOutputModel : CarAdsOutputModel<MyCarAdOutputModel>
    {
        public MyCarAdsOutputModel(IEnumerable<MyCarAdOutputModel> carAds,
            int page,
            int totalPages)
            : base(carAds, page, totalPages)
        {
        }
    }
}
