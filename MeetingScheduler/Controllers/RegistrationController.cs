using MeetingScheduler.Authentication.Contract;
using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using System;
using System.Net;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    public class RegistrationController : ApiController
    {
        private readonly IRegistration registration;
        private readonly IToken tokenHandler;
        public RegistrationController(IRegistration registration, IToken tokenHandler)
        {
            if (registration == null)
                throw new ArgumentNullException(nameof(registration));
            if (tokenHandler == null)
                throw new ArgumentNullException(nameof(tokenHandler));
            this.registration = registration;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        public string SignUp(Visitor visitor)
        {
            var userId = registration.SignUp(visitor);
            if (userId > 0)
                return "/api/login";
            else
                throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
        }

        
    }
}
