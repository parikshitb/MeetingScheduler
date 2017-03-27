using MeetingScheduler.Entity;
using MeetingScheduler.Filter;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    [CustomAuthenticationFilter]
    public class MeetingRegistrationController : ApiController
    {
        public MeetingRegistrationController()
        {

        }
        // POST: api/MeetingRegistration
        public void Post(Meeting meeting)
        {
        }
        
        // DELETE: api/MeetingRegistration/5
        public void Delete(int id)
        {
        }
    }
}
