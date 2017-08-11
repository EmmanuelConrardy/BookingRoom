using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingRoomDal;
using BookingRoomServices;
using BookingRoomModels;
using System.Collections.Generic;
using System.Linq;
using BookingRoomModels.Enums;

namespace BookingRoomApi.Tests.Services
{
    [TestClass]
    public class BookingServicesTests
    {
        [TestMethod]
        public void Should_Count_One_Booking_in_Room_one_when_adding_a_booking_on_room_one()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingRepository = new BookingRepository(roomRepository);
            var bookingServices = new BookingServices(bookingRepository);

            bookingServices.Add(new Booking
            {
                BookingRange = new BookingRange(),
                RoomNumber = 1,
                User = new User()
            });

            List<Room> result = roomRepository.GetAll();

            Assert.AreEqual(1,result.First(r => r.Number == 1).Bookings.Count());
        }

        
    }
}
