using BookingRoomModels;
using System.Collections.Generic;

namespace BookingRoomDal.Abstract
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        Room Add(Room room);
        Room Get(int roomNumber);
    }
}