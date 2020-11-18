using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Agile.Abp.Account
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IdentityUserDto> RegisterAsync(PhoneNumberRegisterDto input);

        Task ResetPasswordAsync(PasswordResetDto input);

        Task VerifyPhoneNumberAsync(VerifyDto input);
    }
}
