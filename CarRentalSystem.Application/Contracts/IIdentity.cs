using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Features.Identity;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);
        Task<Result<LoginOutputModel>> Login(UserInputModel userIput);
    }
}
