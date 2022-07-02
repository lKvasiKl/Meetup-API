using Business.Models;

namespace Business.IServices
{
    public interface IAuthService
    {
        Task RegisterUserAsync(RegisterModel registerRequest);
    }
}
