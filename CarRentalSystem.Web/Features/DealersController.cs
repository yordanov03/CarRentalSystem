using CarRentalSystem.Application.Features;
using CarRentalSystem.Application.Features.Dealers.Commands;
using CarRentalSystem.Application.Features.Dealers.Queries.Search;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class DealersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<SearchDealerOutputModel>> SingleDealer(
           [FromRoute] SearchDealerQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> EditDealer(
            int id, [FromRoute] EditDealerCommand command)
            => await this.Send(command.SetId(id));

    }
}
