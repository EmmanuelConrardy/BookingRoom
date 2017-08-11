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
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        private readonly IBookingServices _bookingServices;
        private readonly IRoomServices _roomServices;

        public BookingController(IBookingServices bookingServices, IRoomServices roomServices)
        {
            _bookingServices = bookingServices;
            _roomServices = roomServices;
        }

        /// <summary>
        /// Add a booking, if conflict return available hours
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(List<int>))]
        public IHttpActionResult Post([FromBody]Booking booking)
        {
            try
            {
                if (_roomServices.IsNoConflict(booking))
                {
                    _bookingServices.Add(booking);
                    return Ok();
                }

                var room = _roomServices.Get(booking.RoomNumber);
                var availableHours = _roomServices.GetAvailableHours(room);
                return Content(HttpStatusCode.Conflict, availableHours);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete Booking by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var booking = _bookingServices.Get(id);
                if (booking == null)
                    return NotFound();

                _bookingServices.Delete(id);
                return Ok();

            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
