using MeetingScheduler.Authentication;
using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace MeetingScheduler.Filter
{
    public class CustomAuthenticationFilter : Attribute, IAuthenticationFilter
    {
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
            {
                context.Principal = principal;
                SetPrincipal(principal);
            }
        }
        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null) //web hosting
            {
                HttpContext.Current.User = principal;
            }
        }
        private Task<IPrincipal> AuthenticateJwt(string token)
        {
            var tokenHandler = new Jwt();
            IPrincipal principal = tokenHandler.VerifyToken(token);
            return Task.FromResult(principal);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}