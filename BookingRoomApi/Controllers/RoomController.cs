using BookingRoomModels;
using BookingRoomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookingRoomApi.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        private readonly IRoomServices _roomServices;
        public RoomController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }
        /// <summary>
        /// Return all rooms
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<Room>))]
        public IHttpActionResult Get()
        {
            var room = _roomServices.GetAll();
            return Ok(room);
        }


    }
}
