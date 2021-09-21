using CarRentalSystem.Application.Features;
using CarRentalSystem.Application.Features.CarAds.Commands;
using CarRentalSystem.Application.Features.CarAds.Commands.Edit;
using CarRentalSystem.Application.Features.CarAds.Queries.Categories;
using CarRentalSystem.Application.Features.CarAds.Queries.Details;
using CarRentalSystem.Application.Features.CarAds.Queries.Mine;
using CarRentalSystem.Application.Features.CarAds.Queries.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class CarsAdController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchCarAdsOutputModel>> Search(
            [FromQuery] SearchCarAdsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateCarAdOutputModel>> Create(
            CreateCarAdCommand command)
            => await this.Send(command);

        [HttpGet]
        [Authorize]
        [Route(nameof(My))]
        public async Task<ActionResult<MyCarAdsOutputModel>> My(
            [FromQuery] MyCarAdsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<ActionResult<IEnumerable<CategoryOutputModel>>> Categories(
            [FromQuery] CategoriesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CarAdDetailsOutputModel>> Details(
            [FromRoute] CarAdDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditCarAdCommand command)
            => await this.Send(command.SetId(id));
    }
}
