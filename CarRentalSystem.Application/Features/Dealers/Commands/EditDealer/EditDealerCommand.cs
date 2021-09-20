using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Dealers.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Features.Dealers.EditDealer
{
    public class EditDealerCommand : EntityCommand<int>, IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public class EditDealerCommandHandler : IRequestHandler<EditDealerCommand, Result>
        {
            private readonly IDealerRepository dealerRepository;
            private readonly ICurrentUser currentUser;

            public EditDealerCommandHandler(
                IDealerRepository dealerRepository,
                ICurrentUser currentUser)
            {
                this.dealerRepository = dealerRepository;
                this.currentUser = currentUser;
            }
            public async Task<Result> Handle(EditDealerCommand request, CancellationToken cancellationToken)
            {
                var dealer = await this.dealerRepository.FindById(currentUser.UserId);

                if (request.Id != dealer.Id)
                {
                    return "You cannot edit this dealer.";
                }

                dealer
                    .UpdateName(request.Name)
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.dealerRepository.Save(dealer, cancellationToken);

                return Result.Success;

            }
        }
    }
}
