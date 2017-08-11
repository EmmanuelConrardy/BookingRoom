using BookingRoomApi.Controllers;
using BookingRoomDal;
using BookingRoomServices;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace BookingRoomOwin
{
    public class ControllerActivator : IHttpControllerActivator
    {
        private DefaultHttpControllerActivator defaultHttpControllerActivator;

        public ControllerActivator(DefaultHttpControllerActivator defaultHttpControllerActivator)
        {
            this.defaultHttpControllerActivator = defaultHttpControllerActivator;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof(RoomController))
            {
                var roomService = new RoomServices(RoomRepository.Instance);
                return new RoomController(roomService);
            }
            else if (controllerType == typeof(BookingController))
            {
                var roomService = new RoomServices(RoomRepository.Instance);
                var bookingService = new BookingServices(new BookingRepository(RoomRepository.Instance));
                return new BookingController(bookingService,roomService);
            }
            return this.defaultHttpControllerActivator.Create(request, controllerDescriptor, controllerType);
        }
    }
}