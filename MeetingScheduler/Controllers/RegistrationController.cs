using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using System;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    public class RegistrationController : ApiController
    {
        IRegistration registration;
        public RegistrationController(IRegistration registration)
        {
            if (registration == null)
            {
                throw new ArgumentNullException();
            }
            this.registration = registration;
        }

        [HttpPost]
        public string SignUp(Visitor visitor)
        {
            return registration.SignUp(visitor);
        }
    }
}
