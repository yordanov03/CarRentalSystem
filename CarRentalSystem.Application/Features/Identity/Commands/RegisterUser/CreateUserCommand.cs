using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Features.Dealers;
using CarRentalSystem.Domain.Factories.Dealers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Identity.Commands.RegisterUser
{
    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IDealerFactory dealerFactory;
            private readonly IDealerRepository dealerRepository;

            public CreateUserCommandHandler(IIdentity identity, IDealerFactory dealerFactory, IDealerRepository dealerRepository)
            {
                this.identity = identity;
                this.dealerRepository = dealerRepository;
                this.dealerFactory = dealerFactory;
            }

            public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;
                var dealer = dealerFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeDealer(dealer);

                await this.dealerRepository.Save(dealer, cancellationToken);
                return result;
            }

        }
    }
}
