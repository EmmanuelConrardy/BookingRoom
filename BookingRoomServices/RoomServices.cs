using BookingRoomDal.Abstract;
using System.Collections.Generic;
using BookingRoomModels;
using System;
using System.Linq;

namespace BookingRoomServices
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository _roomRepository;
        private List<int> RangeHours = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        public RoomServices(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room Add(Room room)
        {
            return _roomRepository.Add(room);
        }

        public bool IsNoConflict(Booking booking)
        {
            var room = _roomRepository.Get(booking.RoomNumber);

            if (room == null)
            {
                throw new ArgumentOutOfRangeException("The number of the room doesn't exist");
            }

            var result = room.Bookings.TrueForAll(b => !b.BookingRange.IsConflict(booking.BookingRange));
            return result;
        }

        public List<int> GetAvailableHours(Room room)
        {
            var result = RangeHours;

            foreach (var booking in room.Bookings)
            {
                result.RemoveAll(h => booking.BookingRange.Hours.Contains(h)); 
            }

            return result;
        }

        public Room Get(int roomNumber)
        {
            var room = _roomRepository.Get(roomNumber);

            if (room == null)
                throw new ArgumentException("Room number doesn't exist");

            return room;
        }
    }
}
