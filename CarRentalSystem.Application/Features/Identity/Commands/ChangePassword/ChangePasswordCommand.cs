using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Identity.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result>
    {
        public string CurrentPassword { get; }
        public string NewPassword { get; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IIdentity identity;

            public ChangePasswordCommandHandler(
                ICurrentUser currentUser,
                IIdentity identity)
            {
                this.currentUser = currentUser;
                this.identity = identity;
            }
            public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
