using BookingRoomModels;
using System.Collections.Generic;

namespace BookingRoomServices
{
    public interface IRoomServices
    {
        List<Room> GetAll();
        Room Add(Room room);
        bool IsNoConflict(Booking booking);
        List<int> GetAvailableHours(Room room);
        Room Get(int roomNumber);
    }
}