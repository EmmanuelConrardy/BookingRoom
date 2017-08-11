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
    public class RoomServicesTests
    {
        [TestMethod]
        public void Should_Display_All_Room()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingServices = new RoomServices(roomRepository);

            List<Room> result = bookingServices.GetAll();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Display_One_More_Room_After_Adding_A_New_One()
        {
            var roomRepository = RoomRepository.Instance;
            var bookingServices = new RoomServices(roomRepository);

            bookingServices.Add(new Room
            {
                Bookings = new List<Booking>(),
                Name = "Room1",
                Number = 1
            });

            List<Room> result = bookingServices.GetAll();

            Assert.AreEqual("Room1",result.First().Name);
        }

        [TestMethod]
        public void Should_Return_True_When_Room_Booking_Is_Empty()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingRepository = new BookingRepository(roomRepository);
            var roomServices = new RoomServices(roomRepository);
            var booking = new Booking
            {
                BookingRange = new BookingRange
                {
                    Year = 2017,
                    Mounth = Month.August,
                    Day = 9,
                    Hours = new List<int> { 9, 10, 11 }
                },
                RoomNumber = 1,
                User = new User()
            };

            var result = roomServices.IsNoConflict(booking);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_Return_False_When_Room_Booking_Is_In_Conflict()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingRepository = new BookingRepository(roomRepository);
            var bookingServices = new BookingServices(bookingRepository);
            var roomServices = new RoomServices(roomRepository);
            
            var booking = new Booking
            {
                BookingRange = new BookingRange
                {
                    Year = 2017,
                    Mounth = Month.August,
                    Day = 9,
                    Hours = new List<int> { 9, 10, 11 }
                },
                RoomNumber = 1,
                User = new User()
            };

            bookingServices.Add(booking);

            var result = roomServices.IsNoConflict(booking);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_All_Hours_When_Room_Booking_Is_Empty()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingRepository = new BookingRepository(roomRepository);
            var bookingServices = new BookingServices(bookingRepository);
            var roomServices = new RoomServices(roomRepository);
            var room1 = new Room
            {
                Name = "Room1",
                Bookings = new List<Booking>(),
                Number = 1
            };
            roomRepository.Add(room1);

            var result = roomServices.GetAvailableHours(room1);

            Assert.AreEqual(24,result.Count());
        }

        [TestMethod]
        public void Should_Only_Available_Hours_When_Room_Booking_Is_Not_Empty()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingRepository = new BookingRepository(roomRepository);
            var bookingServices = new BookingServices(bookingRepository);
            var roomServices = new RoomServices(roomRepository);
            var booking = new Booking
            {
                Id = 1,
                BookingRange = new BookingRange
                {
                    Year = 2017,
                    Mounth = Month.August,
                    Day = 9,
                    Hours = new List<int> { 9, 10, 11 }
                },
                RoomNumber = 1,
                User = new User()
            };

            var room1 = new Room
            {
                Name = "Room1",
                Bookings = new List<Booking> { booking },
                Number = 1
            };

            roomRepository.Add(room1);

            var result = roomServices.GetAvailableHours(room1);

            Assert.AreEqual(21, result.Count());
        }

        [TestMethod]
        public void Should_Only_Available_Hours_When_Room_Booking_Has_Two_Booking()
        {
            //I Jump the injection here I'll do it in the Services and api layer
            var roomRepository = RoomRepository.Instance;
            var bookingRepository = new BookingRepository(roomRepository);
            var bookingServices = new BookingServices(bookingRepository);
            var roomServices = new RoomServices(roomRepository);
            var booking1 = new Booking
            {
                Id = 1,
                BookingRange = new BookingRange
                {
                    Year = 2017,
                    Mounth = Month.August,
                    Day = 9,
                    Hours = new List<int> { 9, 10, 11 }
                },
                RoomNumber = 1,
                User = new User()
            };

            var booking2 = new Booking
            {
                Id = 1,
                BookingRange = new BookingRange
                {
                    Year = 2017,
                    Mounth = Month.August,
                    Day = 9,
                    Hours = new List<int> { 15, 16 }
                },
                RoomNumber = 1,
                User = new User()
            };

            var room1 = new Room
            {
                Name = "Room1",
                Bookings = new List<Booking> { booking1, booking2 },
                Number = 1
            };

            roomRepository.Add(room1);

            var result = roomServices.GetAvailableHours(room1);

            Assert.AreEqual(19, result.Count());
        }

    }
}
