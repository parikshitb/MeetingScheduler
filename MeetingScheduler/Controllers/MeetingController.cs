using MeetingScheduler.Authentication;
using MeetingScheduler.Contract;
using MeetingScheduler.Entity;
using MeetingScheduler.Filter;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MeetingScheduler.Controllers
{
    [CustomAuthenticationFilter]
    public class MeetingController : ApiController
    {
        private readonly IMeetingHandler meetingHandler;
        public MeetingController(IMeetingHandler meetingHandler)
        {
            if (meetingHandler == null)
                throw new ArgumentNullException(nameof(meetingHandler));
            this.meetingHandler = meetingHandler;
        }

        // GET: api/Meeting
        public IEnumerable<Meeting> Get()
        {
            return meetingHandler.GetAllMeetings(); 
        }

        // GET: api/Meeting/5
        public Meeting Get(int id)
        {
            return meetingHandler.GetMeeting(id);
        }

        // POST: api/Meeting
        public void Post([FromBody]Meeting value)
        {
            meetingHandler.CreateMeeting(value);
        }

        // PUT: api/Meeting/5
        public void Put(int id, [FromBody]Meeting value)
        {
            value.MeetingId = id;
            meetingHandler.UpdateMeeting(value);
        }

        // DELETE: api/Meeting/5
        public void Delete(int id)
        {
            meetingHandler.DeleteMeeting(id);
        }
    }
}
