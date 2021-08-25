using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Identity.Commands.RegisterUser
{
    public class RegisterUserCommand : UserInputModel, IRequest<Result>
    {
        public RegisterUserCommand(string email, string password) : base(email, password)
        {

        }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
        {
            private readonly IIdentity identity;

            public RegisterUserCommandHandler(IIdentity identity) => this.identity = identity;

            public Task<Result> Handle(
                RegisterUserCommand request,
                CancellationToken cancellationToken)
                => this.identity.Register(request);
        }
    }
}
