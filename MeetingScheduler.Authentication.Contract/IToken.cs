using System.Security.Claims;

namespace MeetingScheduler.Authentication.Contract
{
    public interface IToken
    {
        string CreateToken(string username);
        ClaimsPrincipal VerifyToken(string token);
    }
}
