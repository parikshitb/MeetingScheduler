using System.Security.Claims;

namespace MeetingScheduler.Authentication.Contract
{
    public interface IToken
    {
        string CreateToken(int userId, string username);
        ClaimsPrincipal VerifyToken(string token);
    }
}
