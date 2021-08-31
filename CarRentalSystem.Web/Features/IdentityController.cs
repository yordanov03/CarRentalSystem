namespace CarRentalSystem.Web.Features
{
    using Application.Contracts;
    using Application.Features.Identity;
    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using CarRentalSystem.Application.Features.Identity.Commands.RegisterUser;
    using CarRentalSystem.Web.Common;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ApiController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<IUser>> Register(RegisterUserCommand command)
            => await this.Send(command);


        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
       => await this.Send(command);
    }
}
