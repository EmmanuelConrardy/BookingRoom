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
    public class BookingRepository : IBookingRepository
    {
        private readonly IRoomRepository _roomRepository;

        public BookingRepository(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        
        public Booking Add(Booking booking)
        {
            var room = _roomRepository.Get(booking.RoomNumber);

            room.Bookings.Add(booking);

            return booking;
        }

        //not efficient
        public void Delete(int id)
        {
            var rooms = _roomRepository.GetAll();

            foreach (var room in rooms)
            {
                if(room.Bookings.Any(b => b.Id == id))
                {
                    room.Bookings.RemoveAll(b => b.Id == id);
                    break;
                }
                
            }
        }

        public Booking Get(int id)
        {
            var rooms = _roomRepository.GetAll();

            foreach (var room in rooms)
            {
                if (room.Bookings.Any(b => b.Id == id))
                {
                    return room.Bookings.FirstOrDefault(b => b.Id == id);
                }

            }

            return null;
        }
    }
}
