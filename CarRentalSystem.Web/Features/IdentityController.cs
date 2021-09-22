namespace CarRentalSystem.Web.Features
{
    using Application.Contracts;
    using Application.Features.Identity;
    using CarRentalSystem.Application.Features.Identity.Commands.ChangePassword;
    using CarRentalSystem.Application.Features.Identity.Commands.LoginUser;
    using CarRentalSystem.Application.Features.Identity.Commands.RegisterUser;
    using CarRentalSystem.Web.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<IUser>> Register(CreateUserCommand command)
            => await this.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordCommand command)
            => await this.Send(command);
    }
}
