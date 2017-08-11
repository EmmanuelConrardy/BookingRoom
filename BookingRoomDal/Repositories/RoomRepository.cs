using BookingRoomDal.Abstract;
using BookingRoomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomDal
{
    //Thank to the singleton the _rooList will be share with all the application
    public class RoomRepository : IRoomRepository
    {
        private List<Room> _roomList = new List<Room>();

        static RoomRepository instance = null;
        static readonly object token = new object();

        RoomRepository()
        {
            this._roomList = BouchonRoom.GetBouchonRoom(); //to initialise our data
        }

        public static RoomRepository Instance
        {
            get
            {
                lock (token)
                {
                    if (instance == null)
                    {                     
                        instance = new RoomRepository();
                    }
                    return instance;
                }
            }
        }

        public List<Room> GetAll()
        {
            return _roomList;
        }

        public Room Add(Room room)
        {
            _roomList.Add(room);
            return room;
        }

        public Room Get(int roomNumber)
        {
            return _roomList.FirstOrDefault(r => r.Number == roomNumber);
        }
    }

    public static class BouchonRoom {

        public static List<Room> Rooms = new List<Room>();
        public static List<Room> GetBouchonRoom()
        {
            for(int i = 1; i <= 10; i++)
            {
                Rooms.Add(new Room
                {
                    Bookings = new List<Booking>(),
                    Name = $"Room{i}",
                    Number = i
                });
            }

            return Rooms;
        }
    }
}
