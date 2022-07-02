using System.Security.Claims;

namespace Business.Servises.IServices
{
    public interface ITokenService
    {
        string GenerateJwt(IEnumerable<Claim> claims);
    }
}
