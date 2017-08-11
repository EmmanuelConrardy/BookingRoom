namespace BookingRoomModels
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public User User { get; set; }
        public BookingRange BookingRange { get;set; }
    }
}