using CarRentalSystem.Application.Common;
using CarRentalSystem.Application.Features.Identity;
using CarRentalSystem.Application.Features.Identity.Commands.ChangePassword;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.Contracts
{
    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);
        Task<Result<LoginOutputModel>> Login(UserInputModel userIput);
        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
