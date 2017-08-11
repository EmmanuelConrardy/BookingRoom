using System.Collections.Generic;

namespace BookingRoomModels
{
    public class Room
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}