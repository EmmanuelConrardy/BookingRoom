using BookingRoomModels;

namespace BookingRoomServices
{
    public interface IBookingServices
    {
        Booking Add(Booking room);
        void Delete(int id);
        Booking Get(int id);
    }
}