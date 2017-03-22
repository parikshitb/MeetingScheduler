using MeetingScheduler.Entity;
using System.Collections.Generic;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    public class MeetingController : ApiController
    {
        // GET: api/Meeting
        public IEnumerable<Meeting> Get()
        {
            
        }

        // GET: api/Meeting/5
        public Meeting Get(int id)
        {

        }

        // POST: api/Meeting
        public void Post([FromBody]Meeting value)
        {
        }

        // PUT: api/Meeting/5
        public void Put(int id, [FromBody]Meeting value)
        {
        }

        // DELETE: api/Meeting/5
        public void Delete(int id)
        {
        }
    }
}
