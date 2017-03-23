using MeetingScheduler.Authentication.Contract;
using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MeetingScheduler.Filter
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {
        private readonly IToken tokenHandler;
        public AuthenticationFilter(IToken tokenHandler)
        {
            this.tokenHandler = tokenHandler;
        }
        public bool AllowMultiple => false;
        
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var auth = request.Headers.Authorization;
            if (auth == null || auth.Scheme != "bearer")
                return;
            if (string.IsNullOrEmpty(auth.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }
            var jwt = auth.Parameter;
            var principal = await AuthenticateJwt(jwt);
            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
            else
                context.Principal = principal;
        }

        private Task<IPrincipal> AuthenticateJwt(string token)
        {
            IPrincipal principal = tokenHandler.VerifyToken(token);
            return Task.FromResult(principal);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}