using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserSignIn userSignIn;
        public LoginController(IUserSignIn userSignIn)
        {
            if (userSignIn == null)
            {
                throw new ArgumentNullException(nameof(userSignIn));
            }
            this.userSignIn = userSignIn;
        }
        
        [HttpPost]
        public HttpResponseMessage SignIn(User user)
        {
            userSignIn.SignIn(user);
            return new HttpResponseMessage();
        }

    }
}
