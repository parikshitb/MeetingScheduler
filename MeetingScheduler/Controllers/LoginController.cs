using MeetingScheduler.Authentication.Contract;
using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using System;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserSignIn userSignIn;
        private readonly IToken tokenHandler;
        public LoginController(IUserSignIn userSignIn, IToken tokenHandler)
        {
            if (userSignIn == null)
                throw new ArgumentNullException(nameof(userSignIn));
            if (tokenHandler == null)
                throw new ArgumentNullException(nameof(tokenHandler));
            this.userSignIn = userSignIn;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        public string SignIn(User user)
        {
            int userId = userSignIn.SignIn(user);
            string jwt = null;
            if (userId > 0)
                jwt = tokenHandler.CreateToken(userId, user.Username);
            if (!string.IsNullOrEmpty(jwt))
                return jwt;
            throw new Exception();
        }

    }
}
