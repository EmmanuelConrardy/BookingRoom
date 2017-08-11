using BookingRoomModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BookingRoomModels
{
    public class BookingRange
    {
        public int Year { get; set; }
        public Month Mounth { get; set; }
        public int Day { get; set; }
        public List<int> Hours { get; set; }

        
    }

    public static class BookingRangeExtension
    {
        public static bool IsConflict(this BookingRange currentBooking, BookingRange booking)
        {
            if (currentBooking.Year == booking.Year && currentBooking.Mounth == booking.Mounth
                && currentBooking.Day == booking.Day && currentBooking.Hours.Count > 0)
            {
                var currentStart = currentBooking.Hours.First();
                var currentLast = currentBooking.Hours.Last();
                var start = booking.Hours.First();
                var last = booking.Hours.Last();

                if(currentStart <= last && currentLast >= currentStart)
                {
                    return true;
                }

            }

            return false;
        }
    }
}