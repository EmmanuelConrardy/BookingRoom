using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingRoomModels;
using BookingRoomModels.Enums;
using System.Collections.Generic;

namespace BookingRoomApi.Tests.Extensions
{
    [TestClass]
    public class BookingRangeExtensionTests
    {
        [TestMethod]
        public void Should_Return_False_When_List_Hours_is_Empty()
        {
            var currentBookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int>()
            };

            var bookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 9, 10, 11 }
            };

            var result = currentBookingRange.IsConflict(bookingRange);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Should_Return_True_When_List_Hours_Conflict_By_Start()
        {
            var currentBookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 11, 12 }
            };

            var bookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 9, 10, 11 }
            };

            var result = currentBookingRange.IsConflict(bookingRange);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_Return_True_When_List_Hours_Conflict_By_Last()
        {
            var currentBookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 8, 9 }
            };

            var bookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 9, 10, 11 }
            };

            var result = currentBookingRange.IsConflict(bookingRange);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Should_Return_True_When_List_Hours_Conflict_In_The_Range()
        {
            var currentBookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 10 }
            };

            var bookingRange = new BookingRange
            {
                Year = 2017,
                Mounth = Month.August,
                Day = 9,
                Hours = new List<int> { 9, 10, 11 }
            };

            var result = currentBookingRange.IsConflict(bookingRange);

            Assert.IsTrue(result);
        }
    }
}
